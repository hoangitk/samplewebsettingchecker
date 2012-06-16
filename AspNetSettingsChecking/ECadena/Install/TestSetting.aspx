<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestSetting.aspx.cs" Inherits="ECadena.Install.TestSetting" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Settings Testing</title>
    <script type="text/javascript" language="javascript">
        function beginProcess() {
            // Create an iframe.
            var iframe = document.createElement("iframe");

            // Point the iframe to the location of
            //  the long running process.
            iframe.src = "TestProcess.aspx";

            // Make the iframe invisible.
            iframe.style.display = "none";

            // Add the iframe to the DOM.  The process
            //  will begin execution at this point.
            document.body.appendChild(iframe);

            // Disable the button and blur it.
            document.getElementById('trigger').disabled = true;
            document.getElementById('trigger').blur();

            return false;
        }

        function updateProgress(TaskId, IsSuccess, Message, PercentComplete) {
            //document.getElementById(TaskId).innerText = TaskId + ': ' + IsSuccess + ':' + Message;
            var status = document.getElementById(TaskId).getElementsByClassName("status")[0];
            status.textContent = IsSuccess == "True" ? "Passed" : "Failed";
            updateStatus(status, IsSuccess);

            var detail = document.getElementById(TaskId + "detail").getElementsByClassName("detail")[0];
            //detail.textContent = Message;
            detail.innerHTML = Message;
        }

        function showDetail(DetailId) {
            var detail = document.getElementById(DetailId);
            if (detail.style.display == "none") {
                detail.style.display = "inline";
            }
            else {
                detail.style.display = "none";
            }
        }

        function updateStatus(Status, IsSuccess) {
            Status.style.color = "white";

            if (IsSuccess == "True") {
                Status.style.backgroundColor = "#4CC417";
            }
            else {
                Status.style.backgroundColor = "#F6358A";
            }
        }
    </script>

    <style type="text/css">
        html, body {
            margin: 0;
            padding: 0;
            height: 100%; /* needed for container min-height */
            background: white;
            font-family: arial,sans-serif;
            font-size: small;
            color: #666;
        }

        h1 {
            font: 1.5em georgia,serif;
            margin: 0.5em 0;
        }

        h2 {
            font: 1.25em georgia,serif;
            margin: 0 0 0.5em;
        }

        h1, h2, a {
            color: #fff;
            width: 423px;
        }

        p {
            line-height: 1.5;
            margin: 0 0 1em;
        }

        div#container {
            position: relative; /* needed for footer positioning*/
            margin: 0 auto; /* center, not in IE5 */
            width: 750px;
            background: #fff;
            height: auto !important; /* real browsers */
            height: 100%; /* IE6: treaded as min-height*/
            min-height: 100%; /* real browsers */
        }

        div#header {
            padding: 1em;
            background: #003366;
            border-bottom: 6px gray;
        }

            div#header p {
                font-style: italic;
                font-size: 1.1em;
                margin: 0;
            }

        div#content {
            padding: 1em 1em 5em; /* bottom padding for footer */
        }

            div#content p {
                text-align: justify;
                padding: 0 1em;
            }

        div#footer {
            position: absolute;
            width: 100%;
            bottom: 0; /* stick to bottom */
            background: #003366;
            border-top: 6px gray;
        }

            div#footer p {
                padding: 1em;
                margin: 0;
                color: #fff;
            }

        table {
            width: 650px;
        }

            table tr .title {
                background: #3399FF;
                color: #fff;
                font-weight: bold;
                padding: 5px;
                width: 600px;
            }

            table tr .status {
                padding-left: 10px;
            }

            table tr .detail {                
            }

        #trigger {
            border-style: none;
            border-color: inherit;
            border-width: 0px;
            background: #990099;
            font-weight: bold;
            color: #FFFF99;
        }
    </style>
</head>
<body>
    <div id="container">
        <div id="header">
            <h1>ECadena // Settings Checking</h1>
        </div>
        <div id="body">
            <form id="form1" runat="server">
            <div>
                <input type="submit" runat="server" value=" RUN " id="trigger" onclick="beginProcess(); return false;" align="right" />
            </div>
            <table>
                <tr id="task1" onclick="showDetail('task1detail');" style="cursor: pointer">
                    <td class="title">Windows Server</td>
                    <td class="status">None</td>
                </tr>
                <tr id="task1detail" style="display: none">
                    <td class="detail" colspan="2">detail</td>
                </tr>
                <tr id="task2" onclick="showDetail('task2detail');" style="cursor: pointer">
                    <td class="title">IIS Version</td>
                    <td class="status">None</td>
                </tr>
                <tr id="task2detail" style="display: none">
                    <td class="detail" colspan="2">detail</td>
                </tr>
                <tr id="task3" onclick="showDetail('task3detail');" style="cursor: pointer">
                    <td class="title">.Net Framework</td>
                    <td class="status">None</td>
                </tr>
                <tr id="task3detail" style="display: none">
                    <td class="detail" colspan="2">detail</td>
                </tr>
                <tr id="task4" onclick="showDetail('task4detail');" style="cursor: pointer">
                    <td class="title">IIS Configuration</td>
                    <td class="status">None</td>
                </tr>
                <tr id="task4detail" style="display: none">
                    <td class="detail" colspan="2">detail</td>
                </tr>
                <tr id="task5" onclick="showDetail('task5detail');" style="cursor: pointer">
                    <td class="title" style="height: 28px">Permissions</td>
                    <td class="status" style="height: 28px">None</td>
                </tr>
                <tr id="task5detail" style="display: none">
                    <td class="detail" colspan="2">detail</td>
                </tr>
                <tr id="task6" onclick="showDetail('task6detail');" style="cursor: pointer">
                    <td class="title">MS SQL</td>
                    <td class="status">None</td>
                </tr>
                <tr id="task6detail" style="display: none">
                    <td class="detail" colspan="2">detail</td>
                </tr>
                <tr id="task7" onclick="showDetail('task7detail');" style="cursor: pointer">
                    <td class="title">Email</td>
                    <td class="status">None</td>
                </tr>
                <tr id="task7detail" style="display: none">
                    <td class="detail" colspan="2">detail</td>
                </tr>
            </table>
            </form>
        </div>

        <div id="footer" align="center">
            <p>Copyright © Cadena HRM Series, 2012</p>
        </div>
    </div>
</body>
</html>
