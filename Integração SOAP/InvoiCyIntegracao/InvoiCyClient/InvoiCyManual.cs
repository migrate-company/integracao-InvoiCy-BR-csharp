using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace InvoiCy
{
    public class InvoiCyClient
    {

        public InvoiCyClient()
        {
            // método construtor
        }

        // atributos públicos de entrada
        public string UrlWs { get; set; }
        public string Soap { get; set; }

        //atributos públicos de saída
        public int ErrorCode { get; set; }
        public string SoapRet { get; set; }
        public string ErrorDesc { get; set; }

        //Função que executa requisição ao Web service
        public void ExecutaWS()
        {

            //faz o requisição ao invoiCy
            try
            {
                HttpWebRequest req = (HttpWebRequest) WebRequest.Create(UrlWs);
                req.Method = "POST";

                using (System.IO.Stream stm = req.GetRequestStream())
                {
                    using (System.IO.StreamWriter stmw = new System.IO.StreamWriter(stm))
                    {
                        stmw.Write(Soap);
                        stmw.Close();
                        stmw.Dispose();
                    }
                    stm.Close();
                    stm.Dispose();
                }

                //Faz a leitura do retorno da chamada
                try
                {
                    System.Net.WebResponse response = req.GetResponse();
                    System.IO.StreamReader responseStream = new System.IO.StreamReader(response.GetResponseStream());

                    SoapRet = responseStream.ReadToEnd().Trim().Replace("\n", "").Replace("\t", "");

                    ErrorCode = 100;
                    responseStream.Close();
                    responseStream.Dispose();

                }
                //Falha na requisição
                catch (WebException wexc)
                {
                    System.Net.HttpWebResponse resp = wexc.Response as System.Net.HttpWebResponse;
                    System.IO.StreamReader responseStream = new System.IO.StreamReader(resp.GetResponseStream());
                    SoapRet = responseStream.ReadToEnd();
                    
                    ErrorDesc = "Falha na comunicação: " + SoapRet;
                    ErrorCode = 801;
                    responseStream.Close();
                    responseStream.Dispose();

                }

            }
            //falha na requisição  
            catch (Exception exc)
            {            
                ErrorCode = 999;
                ErrorDesc = exc.Message + exc.StackTrace;

            }
        }

        //Função que realiza a escrita do SOAP
        public string EscreveSoap(string xml, string EmpPK, string HashGerado)
        {
            //Lineariza o XML do documento           
            xml = xml.Replace("(?ism)(?<=>)[^a-z|0-9]*(?=<)","");

            //Converte para texto o xml do documento
            String XmlEnvio = xml;
	        XmlEnvio = XmlEnvio.Replace("<","&lt;");
	        XmlEnvio = XmlEnvio.Replace(">","&gt;");
	        XmlEnvio = XmlEnvio.Replace("\"","&quot;");

            String sBody = "";

            sBody += "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:inv=\"InvoiCy\">";
            sBody += "<soapenv:Header/>";
            sBody += "<soapenv:Body>";
	        sBody +=     "<inv:recepcao.Execute>";
            sBody +=         "<inv:Invoicyrecepcao>";
			sBody +=            "<inv:Cabecalho>";
			sBody +=                "<inv:EmpPK>" + EmpPK + "</inv:EmpPK>";
            sBody +=                 "<inv:EmpCK>" + HashGerado + "</inv:EmpCK>";
	        sBody +=                 "<inv:EmpCO></inv:EmpCO>";
            sBody +=             "</inv:Cabecalho>";
            sBody +=            "<inv:Informacoes>";
	        sBody +=                   "<inv:Texto></inv:Texto>";
            sBody +=            "</inv:Informacoes>";
            sBody +=            "<inv:Dados>";
	        sBody +=                "<inv:DadosItem>";
           	sBody +=                     "<inv:Documento>" + XmlEnvio + "</inv:Documento>";
			sBody +=                     "<inv:Parametros></inv:Parametros>";
			sBody +=               "</inv:DadosItem>";

            //Caso deseja enviar mais de um documento, repetir a tag "DadosItem"

			sBody +=             "</inv:Dados>";
		    sBody +=         "</inv:Invoicyrecepcao>";		                  
	        sBody +=     "</inv:recepcao.Execute>";
            sBody += "</soapenv:Body>";
            sBody += "</soapenv:Envelope>";   

            return sBody;
        }

    }
}
