using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;


public partial class Сertificate : System.Web.UI.Page
{
    //public string adress; 
    public System.DateTime time;
    public XmlNode allDataByStudent;
    string str = "";
    public string have, be, got, sc, stat;

    protected void Page_Load(object sender, EventArgs e)
    {
        time = DateTime.Now;
        try
        {
            str = Request.QueryString["entercode"];
            String[] words = str.Split('_');
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"C:\inetpub\vhosts\u0539005.plsk.regruhosting.ru\httpdocs\mycheckcentr.ru\App_Data\os" + words[0] + ".xml");
            XmlNodeList listXML = xDoc.GetElementsByTagName("number");
            foreach (XmlNode elem in listXML)
            {
                if (elem.InnerText == words[1])
                {
                    allDataByStudent=elem.ParentNode;
                    if (allDataByStudent["sex"].InnerText == "Муж.")
                    {
                        have = "участвовал";
                        be = "стал";
                        got = "получил";
                    }
                    else
                    {
                        have = "участвовала";
                        be = "стала";
                        got = "получила";
                    }

                    int a = int.Parse(allDataByStudent["score"].InnerText.Substring(allDataByStudent["score"].InnerText.Length -1));
                    if(a>1&&a<5){
                        sc = "балла";
                    }
                    else if(a==1){
                        sc = "балл";
                    }
                    else
                    {
                        sc = "баллов";
                    }

                    switch (allDataByStudent["result"].InnerText){
                        case "Участник":
                            stat = "участником";
                            break;
                        case "Диплом I степени":
                            stat = "дипломантом I степени";
                            break;
                        case "Диплом II степени":
                            stat = "дипломантом I степени";
                            break;
                        case "Диплом III степени":
                            stat = "дипломантом I степени";
                            break;
                    }
                    return;
                }
            }
            Response.Redirect("Default.aspx?msg=abs");
            
        }
        catch (Exception err)
        {
            Response.Redirect("Default.aspx?msg=abs");
        }
        
    }

        
}