<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Сertificate.aspx.cs" Inherits="Сertificate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
<meta http-equiv="Cache-Control" content="no-cache" />
 <title>Справка о результатах участия</title>
<link rel="stylesheet" href="~/css/style.css" />
</head>
<body>   
    <!-- Вывод все информации -->
    <div id="document">
        <div id="header">
            Дирекция по профессиональной ориентации и работе с одаренными учащимися<br />
            Национального исследовательского университета<br /> «Высшая школа экономики».
        </div>
        <div id="there">
            По месту требования.
        </div>
        <div id="title">Справка</div>
        <div id="generalText">
            Подтверждаю, что <%= allDataByStudent["surname"].InnerText %> 
            <%= allDataByStudent["name"].InnerText %> 
            <%= allDataByStudent["patronymic"].InnerText %> 
            <%= have %> в олимпиаде Национального исследовательского университета 
            «Высшая школа экономики» для студентов и выпускников, 
            проводимой в <%= int.Parse(allDataByStudent["group"].InnerText)-1 %>/<%= allDataByStudent["group"].InnerText %> 
            учебном году, 
            и по результатам участия в олимпиаде <%= got %> <%= allDataByStudent["score"].InnerText %> <%= sc %> из 100, 
            и <%= be %> <%= stat %> 
            по направлению "<%= allDataByStudent["heading"].InnerText %>" 
            (профиль "<%= allDataByStudent["section"].InnerText %>").
        </div>
        <div id="date">
            Дата выдачи: <%= time.ToShortDateString() %>
            <img id="stamp" src="https://chart.googleapis.com/chart?chs=300x300&cht=qr&chl=http://mycheckcentr.ru/PDF.aspx?<%= Request.QueryString.ToString() %>" />
        </div>
        

    </div>
    
</body>
</html>