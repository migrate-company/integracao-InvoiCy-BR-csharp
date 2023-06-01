using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InvoiCy;
using System.Xml;
using InvoiCyNfeClient;

namespace InvoiCyNfeClient
{
    public partial class InvoiCyIntegracao : Form
    {
        public InvoiCyIntegracao()
        {
            InitializeComponent();            
        }

        private void btnExecutar_Click(object sender, EventArgs e)
        {
            //Exemplo de envio com Web Reference
            EnvioAutomatico();
            
            //Exemplo de envio escrevendo o SOAP
            //EnvioManual();
        }

        private void EnvioManual()
        {
            //Gera CK
            string CK = GeraHashMD5(txtXML.Text);

            //instancia um objeto da classe de envio ao webservice e atribui a eles os parametros necessários.
            InvoiCyClient client = new InvoiCyClient();
            client.UrlWs = "https://homolog.invoicy.com.br/arecepcao.aspx?wsdl";
            client.Soap = client.EscreveSoap(txtXML.Text, txtChaveParceiro.Text, CK);

            //Recebe o retorno da requisição.
            client.ExecutaWS();

            //Busca o código e a descrição de retorno.
            String descricaoRetorno = client.SoapRet.Substring(client.SoapRet.IndexOf("<Descricao>"), client.SoapRet.IndexOf("</Descricao>") - client.SoapRet.IndexOf("<Descricao>")).Replace("<Descricao>", "");
            String codigoRetorno = client.SoapRet.Substring(client.SoapRet.IndexOf("<Codigo>"), client.SoapRet.IndexOf("</Codigo>") - client.SoapRet.IndexOf("<Codigo>")).Replace("<Codigo>", "");

            //Mostra em tela a mensagem e o documento de retorno da requisição.
            txtRetDocumento.Text = "";
            txtRetMensagem.Text = "";
            if (client.ErrorCode == 100)
            {
                txtRetMensagem.Text = codigoRetorno + " - " + descricaoRetorno;     //Sucesso no envio
            }
            else
            {
                txtRetMensagem.Text = client.ErrorCode + " - " + client.ErrorDesc;  //Retorna erros ocorridos no envio
            }
            txtRetDocumento.Text = client.SoapRet;

        }

        private void EnvioAutomatico()
        {

            String texto = txtXML.Text;

            //Cria um objeto para guardar os dados do cabeçalho da conexão
            InvoiCyRecepcao.InvoiCyRecepcaoCabecalho cab = new InvoiCyRecepcao.InvoiCyRecepcaoCabecalho();
            cab.EmpPK = txtChaveParceiro.Text;
            cab.EmpCO = "";

            //Chama a função que gera a CK, e depois adiciona a mesma no cabeçalho.
            cab.EmpCK = GeraHashMD5(texto);

            //Armazena os dados da requisição.
            InvoiCyRecepcao.InvoiCyRecepcaoDadosItem dados = new InvoiCyRecepcao.InvoiCyRecepcaoDadosItem();
            dados.Documento = texto.Trim();
            dados.Parametros = "";   

            //Adiciona os dados na recepção
            InvoiCyRecepcao.InvoiCy IVC = new InvoiCyRecepcao.InvoiCy();
            IVC.Cabecalho = cab;
            IVC.Dados = new InvoiCyRecepcao.InvoiCyRecepcaoDadosItem[1];
            IVC.Dados[0] = dados;
            //Exemplo de envio de somente um documento, porém vários podem ser adicionados na mesma chamada

           
            //Adiciona as informações da requisição
            InvoiCyRecepcao.InvoiCyRecepcaoInformacoes Info = new InvoiCyRecepcao.InvoiCyRecepcaoInformacoes();
            Info.Texto = "";
            IVC.Informacoes = Info;

            //Envia e recebe o retorno da requisição.
            InvoiCyRecepcao.recepcao recepcao = new InvoiCyRecepcao.recepcao();
            InvoiCyRecepcao.Invoicyretorno retorno = recepcao.Execute(IVC);

            //Leitura do retorno
            txtRetMensagem.Text = "";
            foreach (InvoiCyRecepcao.InvoiCyRetornoMensagemItem msgitem in retorno.Mensagem)
            {
                txtRetMensagem.Text += msgitem.Codigo.ToString()+" - "+msgitem.Descricao;
                
                if (msgitem.Documentos != null)
                {
                    foreach (InvoiCyRecepcao.InvoiCyRetornoMensagemItemDocumentosItem docitem in msgitem.Documentos)
                    {
                        txtRetDocumento.Text += docitem.Documento.Trim();
                    }
                }

            }
        }

        //Função de geração de hashMD5 para CK.
        public String GeraHashMD5(string texto)
        {
            using (System.Security.Cryptography.MD5 md5Hash = System.Security.Cryptography.MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(txtChaveComunicacao.Text + texto.Trim()));

                System.Text.StringBuilder sBuilder = new System.Text.StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }
        }

    }
}
