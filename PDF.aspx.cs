using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SelectPdf;
using System.Xml;
using System.Diagnostics;


public partial class PDF : System.Web.UI.Page
{
    
    private const string DOMAIN= @"http://mycheckcentr.ru";
    private string entercode = "";
    private XmlNode fine;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["entercode"]!=null)
        {
            string a = DOMAIN + @"/Сertificate.aspx?entercode=" + Request.QueryString["entercode"].ToString();
            HtmlToPdf converter = new HtmlToPdf();
            converter.ConvertUrl(a).Save(@"C:\inetpub\vhosts\u0539005.plsk.regruhosting.ru\httpdocs\mycheckcentr.ru\pdf\" + Request.QueryString["entercode"].ToString() + ".pdf");
            Server.TransferRequest(@"/pdf/" + Request.QueryString["entercode"].Split('_')[1] + ".pdf");
        }
        else
        {
            try
            {
                Certificate my = new Certificate(Page.Request["Year"], Page.Request["Family"], Page.Request["Name"], Page.Request["Patronymic"], Page.Request["Calendar"]);
                my.Initial();
                if ((fine = my.Fined()) == null)
                {
                    Response.Redirect("Default.aspx?msg=abs");
                }
            }
            catch (Exception err)
            {
                Response.Redirect("Default.aspx?msg=abs");
            }
            entercode = fine.InnerText;
            //Конвертация html в pdf
            HtmlToPdf converter = new HtmlToPdf();
            string a = DOMAIN + @"/Сertificate.aspx?entercode=" + Page.Request["Year"] + "_" + entercode;
            //Debug.Print(a);
            converter.ConvertUrl(a).Save(@"C:\inetpub\vhosts\u0539005.plsk.regruhosting.ru\httpdocs\mycheckcentr.ru\pdf\" + entercode + ".pdf");
            
            Server.TransferRequest(@"~/pdf/" + entercode + ".pdf");
        }
      
    }

    protected void Page_Unload(object sender, EventArgs e)
    {

        //Просмотр файлов в каталог и удаление лишних при достижении их количества 50 штук
        string[] s= Directory.GetFiles(@"C:\inetpub\vhosts\u0539005.plsk.regruhosting.ru\httpdocs\mycheckcentr.ru\pdf\");
        int i = s.Length;
        if (i > 50)
        {
            for(int j=0; j<35; j++)
            {
                File.Delete(s[j]);
            }
        }
        
    }
}