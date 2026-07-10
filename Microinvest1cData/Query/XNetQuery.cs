using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xNet;
using System.Xml;
using System.IO;


namespace Microinvest1cData.Query
{
    class XNetQuery // Класс для отправки в запроса в ЕГАИС
    {

        private String Otvet; //ответ из егаис
        private String URL;
        private bool test = false;
        public  void netQuery(String files, String URL)
        {
            
            try
            {
              using(HttpRequest request = new HttpRequest()){

                request.AddFile("xml_file", @files);
                String xml = request.Post(URL).ToString();
                parser(xml);
                request.Close();

               File.Delete(files);
            }
                
                //MessageBox.Show("Запрос успешно отправлен");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void outQuery(String URL)
        {

            try
            {
                using (HttpRequest request = new HttpRequest())
                {

                    Otvet = request.Get(URL).ToString();
                    if (Otvet == null) Otvet = "";
                    //request.Close();
                  
                }

                test = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //Otvet = "";
                //MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }
        public String getOtvet()
        {
            return Otvet;
        }
        public bool isConnectiv()
        {
            return test;
        }

        private void parser(String xm)
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml(xm);
            XmlElement root = document.DocumentElement;
            XmlNode node = root.ChildNodes[0];
            URL = node.InnerText;
        }
        public void deleteDocument(String url)
        {
            using (var request = new HttpRequest())
            {
               
                var response = request.Raw(HttpMethod.DELETE, url);
            }
        }
        public String getUrl()
        {
            return URL;
        }

        public String xmlQvery(String t)
        {
            try
            {
                using (HttpRequest request = new HttpRequest())
                {
                   return request.Get(t).ToString();
                }

               
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return "";
        }
    }
    
    

}
