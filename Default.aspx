<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta http-equiv="Cache-Control" content="no-cache" />    
    <title>Олимпиада</title>
    <link rel="stylesheet" href="/css/style.css" />
</head>
<body id="form">
    <!-- Отправка Get запроса через HTML форму не засирает адрессную строку ViewState-->
    <div id="header" style="text-align:center; margin:20px">
        Дирекция по профессиональной ориентации и работе с одаренными учащимися<br />
        Национального исследовательского университета<br /> «Высшая школа экономики».
    </div>
    <div id="there" style="text-align:center; margin:12px">
        Верификация данных об участнике олимпиады для студентов и выпускников.
    </div>
    
        <form id="innerform" method="get" action="/PDF.aspx">
            <!---->
            <div>
                <p>
                    Год участия в олимпиаде:
                    <select name="Year">
                        <option>2017</option>
                        <option>2018</option>
                        <!-- <option>2019</option> -->
                    </select>
                </p>

                <p>
                    Фамилия:
                    <input name="Family" type="text" />
                </p>

                <p>
                    Имя:
                    <input name="Name" type="text" />
                </p>

                <p>
                    Отчество:
                    <input name="Patronymic" type="text" />
                </p>

                <p>Дата рождения: <input type="date" name="Calendar" /></p><br />

                <input type="submit" value="Получить сертификат" id="Button" />

            </div>
        </form>
    <div id="botom">
        <% if(Request.QueryString["msg"]=="abs") {Response.Write( "Данный пользователь не найден!");} %>
    </div>
</body>
</html>
