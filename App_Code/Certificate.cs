using System.Xml;
using System.Web.UI;

/// <summary>
/// Сводное описание для Certificate
/// </summary>
public class Certificate
{
    protected string gettingYear;
    protected string gettingSurname;
    protected string gettingName;
    protected string gettingPatronymic;
    protected string gettingDOB;

    protected XmlDocument xDoc;
    protected XmlNodeList listXML;

    public Certificate(string Year, string Surname, string Name, string Patronymic, string DOB)
    {
        gettingYear = Year;
        gettingSurname = Surname;
        gettingName = Name;
        gettingPatronymic = Patronymic;
        gettingDOB = DOB;
    }

    public void Initial()
    {
        // Объект с управляющими элементами
        Page x = new Page();
        // Создаем переменную для xml документа
        xDoc = new XmlDocument();
        
        // загружаем документ
        /*Проверить на отсутствие файла*/
        xDoc.Load(x.Server.MapPath(@"~/App_Data/os" + gettingYear + ".xml"));

    }

    public XmlNode Fined()
    {    
        // получаем элемент по имени
        XmlNodeList listXML = xDoc.GetElementsByTagName("surname");

        foreach (XmlNode elem in listXML)
        {
            if(elem.InnerText == gettingSurname)
            {
                if (elem.ParentNode["name"].InnerText == gettingName)
                {
                    if (elem.ParentNode["patronymic"].InnerText ==gettingPatronymic)
                    {
                        if (elem.ParentNode["DOB"].InnerText == gettingDOB)
                        {
                            return elem.ParentNode["number"];
                        }
                        else { continue; }
                    }
                    else { continue; }
                }
                else { continue; }
            }
        }
        
        return null;
    }
}