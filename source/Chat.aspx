<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Chat.aspx.cs" Inherits="Chat" MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>MyChat聊天室</title>
    <script src="Scripts/jquery-1.8.3.js"></script>
    <script type="text/javascript">
        //window.onbeforeunload = function () { document.getElementById('').click(); };
        window.onload = function () { fullscreen(); }
        
        function BindEnter() {
            if (event.keyCode == 13 && event.srcElement.type == "text") {
                SendMsg();
                event.returnValue = false;
            }
            else {
                event.returnValue = true;
            }
        }

        function timer() {
            setInterval(RunAjax, 2000);
            SetScrollPosition();
            var txt = document.getElementById("sendTextBox");
            txt.value = "";
        }

        function RunAjax() {
            GetMsg();
            GetAnn();
            GetLst();
            GetOl();
        }

        function GetMsg() {
            $.ajax({
                type: "GET",
                url: "DoRequest.aspx",
                data: "mod=ajax&func=gmsg&cache="+new Date(),
                success: function (msg) {
                    $("#ct").html(msg);
                    SetScrollPosition()
                }
            })
        }

        function GetAnn()
        {
            $.ajax({
                type: "GET",
                url: "DoRequest.aspx",
                data: "mod=ajax&func=gann&cache=" + new Date(),
                success: function (msg) {
                    $("#anc").html(msg);
                }
            })
        }

        function GetLst()
        {
            $.ajax({
                type: "GET",
                url: "DoRequest.aspx",
                data: "mod=ajax&func=glst&cache=" + new Date(),
                success: function (msg) {
                    $("#flist").html(msg);
                }
            })
        }

        function GetOl() {
            $.ajax({
                type: "GET",
                url: "DoRequest.aspx",
                data: "mod=ajax&func=gol&cache=" + new Date(),
                success: function (msg) {
                    document.getElementById("<%=countLable.ClientID%>").innerHTML = msg;
                }
            })
        }

        function SendMsg() {
            var txt = document.getElementById("sendTextBox");
            var msg = txt.value;
            if (msg != "") {
                var col = $("#DropDownList1").val();
                var isvip = "<%=isvip%>";
                $.ajax({
                    type: "GET",
                    url: "DoRequest.aspx",
                    data: "mod=ajax&func=sms&msg=" + msg + "&vip=" + isvip + "&color=" + col + "&cache=" + new Date(),
                    success: function () {
                        GetMsg();
                        txt.value = "";
                        txt.focus();
                    }
                })
            }
            
        }

        function fullscreen() {
            var iWidth = window.screen.availWidth;
            var iHeight = window.screen.availHeight;
            window.moveTo(0, 0);
            window.resizeTo(iWidth, iHeight);
        }

        function newpm(fn, isvip) {
            var vip = isvip;
            if (vip != "True") {
                var fname = fn.text;
                $.ajax({
                    type: "GET",
                    url: "DoRequest.aspx",
                    data: "mod=pm&fname=" + fname,
                    success: function (status) {
                        if (status == "ok") {
                            var txt = document.getElementById("sendTextBox");
                            txt.value = "对" + fname + "说：";
                            $("#sendTextBox").focus();
                        }
                        else {
                            alert("无法向自己发送悄悄话");
                        }
                    }
                }
                    )
            }
            else {
                alert("成为vip后即可发送悄悄话~");
            }
        }

        function SetScrollPosition() {
            var frame = document.getElementById("ct");
            frame.scrollTop = 9999999;
        }

        function SetToEnd(txtMessage) {
            if (txtMessage.createTextRange) {
                var fieldRange = txtMessage.createTextRange();
                fieldRange.moveStart('character', txtMessage.value.length);
                fieldRange.collapse();
                fieldRange.select();
            }
        }

        function InsertBq() {
            var vip = "<%=isvip%>";
            if (vip == "True") {
                var htm = "<div style='overflow-y: scroll;height:310px;'><img src=Image/bq/f000.gif loop=-1 id=000 onclick=GetBq(this) /><img src=Image/bq/f001.gif loop=-1 id=001 onclick=GetBq(this) /><img src=Image/bq/f002.gif loop=-1 id=002 onclick=GetBq(this) /><img src=Image/bq/f003.gif loop=-1 id=003 onclick=GetBq(this) /><img src=Image/bq/f004.gif loop=-1 id=004 onclick=GetBq(this) /><img src=Image/bq/f005.gif loop=-1 id=005 onclick=GetBq(this) /><img src=Image/bq/f006.gif loop=-1 id=006 onclick=GetBq(this) /><img src=Image/bq/f007.gif loop=-1 id=007 onclick=GetBq(this) /><img src=Image/bq/f008.gif loop=-1 id=008 onclick=GetBq(this) /><img src=Image/bq/f009.gif loop=-1 id=009 onclick=GetBq(this) /><img src=Image/bq/f010.gif loop=-1 id=010 onclick=GetBq(this) /><img src=Image/bq/f011.gif loop=-1 id=011 onclick=GetBq(this) /><img src=Image/bq/f012.gif loop=-1 id=012 onclick=GetBq(this) /><img src=Image/bq/f013.gif loop=-1 id=013 onclick=GetBq(this) /><img src=Image/bq/f014.gif loop=-1 id=014 onclick=GetBq(this) /><img src=Image/bq/f015.gif loop=-1 id=015 onclick=GetBq(this) /><img src=Image/bq/f016.gif loop=-1 id=016 onclick=GetBq(this) /><img src=Image/bq/f017.gif loop=-1 id=017 onclick=GetBq(this) /><img src=Image/bq/f018.gif loop=-1 id=018 onclick=GetBq(this) /><img src=Image/bq/f019.gif loop=-1 id=019 onclick=GetBq(this) /><img src=Image/bq/f020.gif loop=-1 id=020 onclick=GetBq(this) /><img src=Image/bq/f021.gif loop=-1 id=021 onclick=GetBq(this) /><img src=Image/bq/f022.gif loop=-1 id=022 onclick=GetBq(this) /><img src=Image/bq/f023.gif loop=-1 id=023 onclick=GetBq(this) /><img src=Image/bq/f024.gif loop=-1 id=024 onclick=GetBq(this) /><img src=Image/bq/f025.gif loop=-1 id=025 onclick=GetBq(this) /><img src=Image/bq/f026.gif loop=-1 id=026 onclick=GetBq(this) /><img src=Image/bq/f027.gif loop=-1 id=027 onclick=GetBq(this) /><img src=Image/bq/f028.gif loop=-1 id=028 onclick=GetBq(this) /><img src=Image/bq/f029.gif loop=-1 id=029 onclick=GetBq(this) /><img src=Image/bq/f030.gif loop=-1 id=030 onclick=GetBq(this) /><img src=Image/bq/f031.gif loop=-1 id=031 onclick=GetBq(this) /><img src=Image/bq/f032.gif loop=-1 id=032 onclick=GetBq(this) /><img src=Image/bq/f033.gif loop=-1 id=033 onclick=GetBq(this) /><img src=Image/bq/f034.gif loop=-1 id=034 onclick=GetBq(this) /><img src=Image/bq/f035.gif loop=-1 id=035 onclick=GetBq(this) /><img src=Image/bq/f036.gif loop=-1 id=036 onclick=GetBq(this) /><img src=Image/bq/f037.gif loop=-1 id=037 onclick=GetBq(this) /><img src=Image/bq/f038.gif loop=-1 id=038 onclick=GetBq(this) /><img src=Image/bq/f039.gif loop=-1 id=039 onclick=GetBq(this) /><img src=Image/bq/f040.gif loop=-1 id=040 onclick=GetBq(this) /><img src=Image/bq/f041.gif loop=-1 id=041 onclick=GetBq(this) /><img src=Image/bq/f042.gif loop=-1 id=042 onclick=GetBq(this) /><img src=Image/bq/f043.gif loop=-1 id=043 onclick=GetBq(this) /><img src=Image/bq/f044.gif loop=-1 id=044 onclick=GetBq(this) /><img src=Image/bq/f045.gif loop=-1 id=045 onclick=GetBq(this) /><img src=Image/bq/f046.gif loop=-1 id=046 onclick=GetBq(this) /><img src=Image/bq/f047.gif loop=-1 id=047 onclick=GetBq(this) /><img src=Image/bq/f048.gif loop=-1 id=048 onclick=GetBq(this) /><img src=Image/bq/f049.gif loop=-1 id=049 onclick=GetBq(this) /><img src=Image/bq/f050.gif loop=-1 id=050 onclick=GetBq(this) /><img src=Image/bq/f051.gif loop=-1 id=051 onclick=GetBq(this) /><img src=Image/bq/f052.gif loop=-1 id=052 onclick=GetBq(this) /><img src=Image/bq/f053.gif loop=-1 id=053 onclick=GetBq(this) /><img src=Image/bq/f054.gif loop=-1 id=054 onclick=GetBq(this) /><img src=Image/bq/f055.gif loop=-1 id=055 onclick=GetBq(this) /><img src=Image/bq/f056.gif loop=-1 id=056 onclick=GetBq(this) /><img src=Image/bq/f057.gif loop=-1 id=057 onclick=GetBq(this) /><img src=Image/bq/f058.gif loop=-1 id=058 onclick=GetBq(this) /><img src=Image/bq/f059.gif loop=-1 id=059 onclick=GetBq(this) /><img src=Image/bq/f060.gif loop=-1 id=060 onclick=GetBq(this) /><img src=Image/bq/f061.gif loop=-1 id=061 onclick=GetBq(this) /><img src=Image/bq/f062.gif loop=-1 id=062 onclick=GetBq(this) /><img src=Image/bq/f063.gif loop=-1 id=063 onclick=GetBq(this) /><img src=Image/bq/f064.gif loop=-1 id=064 onclick=GetBq(this) /><img src=Image/bq/f065.gif loop=-1 id=065 onclick=GetBq(this) /><img src=Image/bq/f066.gif loop=-1 id=066 onclick=GetBq(this) /><img src=Image/bq/f067.gif loop=-1 id=067 onclick=GetBq(this) /><img src=Image/bq/f068.gif loop=-1 id=068 onclick=GetBq(this) /><img src=Image/bq/f069.gif loop=-1 id=069 onclick=GetBq(this) /><img src=Image/bq/f070.gif loop=-1 id=070 onclick=GetBq(this) /><img src=Image/bq/f071.gif loop=-1 id=071 onclick=GetBq(this) /><img src=Image/bq/f072.gif loop=-1 id=072 onclick=GetBq(this) /><img src=Image/bq/f073.gif loop=-1 id=073 onclick=GetBq(this) /><img src=Image/bq/f074.gif loop=-1 id=074 onclick=GetBq(this) /><img src=Image/bq/f075.gif loop=-1 id=075 onclick=GetBq(this) /><img src=Image/bq/f076.gif loop=-1 id=076 onclick=GetBq(this) /><img src=Image/bq/f077.gif loop=-1 id=077 onclick=GetBq(this) /><img src=Image/bq/f078.gif loop=-1 id=078 onclick=GetBq(this) /><img src=Image/bq/f079.gif loop=-1 id=079 onclick=GetBq(this) /><img src=Image/bq/f080.gif loop=-1 id=080 onclick=GetBq(this) /><img src=Image/bq/f081.gif loop=-1 id=081 onclick=GetBq(this) /><img src=Image/bq/f082.gif loop=-1 id=082 onclick=GetBq(this) /><img src=Image/bq/f083.gif loop=-1 id=083 onclick=GetBq(this) /><img src=Image/bq/f084.gif loop=-1 id=084 onclick=GetBq(this) /><img src=Image/bq/f085.gif loop=-1 id=085 onclick=GetBq(this) /><img src=Image/bq/f086.gif loop=-1 id=086 onclick=GetBq(this) /><img src=Image/bq/f087.gif loop=-1 id=087 onclick=GetBq(this) /><img src=Image/bq/f088.gif loop=-1 id=088 onclick=GetBq(this) /><img src=Image/bq/f089.gif loop=-1 id=089 onclick=GetBq(this) /><img src=Image/bq/f090.gif loop=-1 id=090 onclick=GetBq(this) /><img src=Image/bq/f091.gif loop=-1 id=091 onclick=GetBq(this) /><img src=Image/bq/f092.gif loop=-1 id=092 onclick=GetBq(this) /><img src=Image/bq/f093.gif loop=-1 id=093 onclick=GetBq(this) /><img src=Image/bq/f094.gif loop=-1 id=094 onclick=GetBq(this) /><img src=Image/bq/f095.gif loop=-1 id=095 onclick=GetBq(this) /><img src=Image/bq/f096.gif loop=-1 id=096 onclick=GetBq(this) /><img src=Image/bq/f097.gif loop=-1 id=097 onclick=GetBq(this) /><img src=Image/bq/f098.gif loop=-1 id=098 onclick=GetBq(this) /><img src=Image/bq/f099.gif loop=-1 id=099 onclick=GetBq(this) /><img src=Image/bq/f100.gif loop=-1 id=100 onclick=GetBq(this) /><img src=Image/bq/f101.gif loop=-1 id=101 onclick=GetBq(this) /><img src=Image/bq/f102.gif loop=-1 id=102 onclick=GetBq(this) /><img src=Image/bq/f103.gif loop=-1 id=103 onclick=GetBq(this) /><img src=Image/bq/f104.gif loop=-1 id=104 onclick=GetBq(this) /><img src=Image/bq/f105.gif loop=-1 id=105 onclick=GetBq(this) /><img src=Image/bq/f106.gif loop=-1 id=106 onclick=GetBq(this) /></div>";
                document.getElementById("infoc").innerHTML = htm;
                light.style.display = 'block';
            }
            else {
                alert("成为vip后即可发送表情~");
            }
        }

        function GetBq(bq) {
            var qqbq = bq.id;
            var txt = document.getElementById("sendTextBox");
            txt.value += "|"+qqbq+"|";
        }

        function getinfo(user) {
            var isuser = "<%=t%>";
            if (isuser == 0) {
                var uname = user.text;
                var light = document.getElementById("light");
                $.ajax({
                    type: "GET",
                    url: "DoRequest.aspx",
                    data: "mod=info&get=" + uname,
                    success: function (htm) {
                        document.getElementById("infoc").innerHTML = htm;
                        light.style.display = 'block';
                    }
                })
            }
            else {
                alert("登陆/注册后即可查看用户信息~");
            }
        }
        function hide() {
            var light = document.getElementById("light");
            light.style.display = 'none';
        }

    </script>

    <style>
        html, body {
            height: 614px;
            width: 100%;
        }

        .white_content {
            display: none;
            background-color:white;
            position: absolute;
            top: 25%;
            left: 35%;
            width: 30%;
            height: 50%;
            border: 8px solid #D6E9F1;
            z-index: 1002;
        }

        .close {
            float: right;
            clear: both;
            width: 100%;
            text-align: right;
            margin: 0 0 6px 0;
        }

            .close a {
                color: #333;
                text-decoration: none;
                font-size: 14px;
                font-weight: 700;
            }

        .con {
            text-indent: 1.5pc;
            line-height: 21px;
        }

        .auto-style1 {
            margin-top:40px;
            width: 80%;
            border: 10px solid #FF3300;
            background-image: url('Image/chat10.jpg');
            background-position: inherit;
        }

        .auto-style2 {
            width: 562px;
            text-align: right;
        }

        .auto-style3 {
            width: 100%;
            text-align: center;
        }

        #FlashWebCamera {
            height: 280px;
            width: 90%;
        }

        .auto-style5 {
            height: 220px;
            Width: 100%;
        }

        .auto-style6 {
            height: 220px;
            width: 47%;
        }

        .auto-style7 {
            width: 562px;
            text-align: right;
            height: 250px;
        }

        .auto-style8 {
            text-align: left;
            Height: 100%;
            Width: 100%;
        }

        .auto-style9 {
            width: 95%;
            height: 496px;
        }

        .auto-style10 {
            height: 36px;
            width: 513px;
            background-color:lightgray;
        }

        .auto-style12 {
            height: 207px;
            width: 513px;
        }

        .auto-style13 {
            height: 40px;
            font-size: medium;
        }

        .auto-style14 {
            height: 618px;
        }

        .auto-style15 {
            font-size: xx-large;
            color: #FFFFFF;
        }

        .auto-style16 {
            font-size: x-large;
            font-weight: bold;
            background-color: #CCFFCC;
        }

        .auto-style17 {
            font-size: large;
            color: #3333CC;
            background-color: #FFFFFF;
        }

        .flist {
            WIDTH: 90%;
            HEIGHT: 200px;
            BACKGROUND-COLOR: #FFFFFF;
            overflow-y: scroll;
            scrollbar-3dlight-color: blue;
            scrollbar-arrow-color: none;
            scrollbar-base-color: white;
            scrollbar-darkshadow-color: none;
            scrollbar-face-color: none;
            scrollbar-highlight-color: none;
            scrollbar-shadow-color: none;
            color: #000099;
            font-weight: 700;
        }

        .chat {
            WIDTH: 100%;
            HEIGHT: 297px;
            overflow-y: scroll;
            scrollbar-3dlight-color: blue;
            scrollbar-arrow-color: none;
            scrollbar-base-color: white;
            scrollbar-darkshadow-color: none;
            scrollbar-face-color: none;
            scrollbar-highlight-color: none;
            scrollbar-shadow-color: none;
        }
        #sendTextBox {
            width: 325px;
            height: 18px;
        }
        .auto-style18 {
            width: 40%;
        }
        .auto-style19 {
            width: 47%;
        }
    </style>
</head>
<body style="background-image:url(Image/chat9.png)" onload="RunAjax();timer();" onkeydown="BindEnter()">
    <form id="form1" runat="server" defaultfocus="sendTextBox">
        <div class="auto-style14">
                <div id="light" class="white_content">
                <div class="close"><a href="javascript:void(0)" onclick="hide()">关闭</a></div>
                <div id="infoc" class="con">
                </div>
            </div>            
            <table align="center" cellpadding="0" cellspacing="0" class="auto-style1" style="width:90%">
                <tr>
                    <td class="auto-style3" colspan="2" style="width:30%"><span class="auto-style16">欢迎来到</span><b><asp:Label ID="roomLable" runat="server" Text="null" CssClass="auto-style15"></asp:Label></b><span class="auto-style16">号聊天室</span></td>
                </tr>
                <tr>
                    <td class="auto-style19"><span class="auto-style17">当前共有</span><asp:Label ID="countLable" runat="server" Text="null" CssClass="auto-style17"></asp:Label><span class="auto-style17">位朋友正在聊天</span></td>
                    <td class="auto-style2" style="width:60%">
                        <asp:Button ID="logoutButton" UseSubmitBehavior="false" runat="server" OnClick="logoutButton_Click" Text="用户退出" BackColor="Black" CssClass="auto-style18" Font-Bold="True" Font-Size="Medium" ForeColor="White" Height="35px" Width="78px" ValidateRequestMode="Disabled" />
                    &nbsp;&nbsp;&nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="auto-style19">
                        <!-- saved from url=(0013)about:internet -->
                        <object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0" id="FlashWebCamera" align="middle">
                            <param name="allowScriptAccess" value="sameDomain" />
                            <param name="movie" value="FlashWebCamera.swf" />
                            <param name="quality" value="high" />
                            <param name="bgcolor" value="#ffffff" />
                            <embed src="FlashWebCamera.swf" quality="high" bgcolor="#ffffff" name="FlashWebCamera" align="middle" allowscriptaccess="sameDomain" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" />
                        </object>
                    </td>
                    <td class="auto-style7" style="width:60%">
                        <div style="float: right; height: 300px; width: 660px;">
                            <div class="auto-style8">
                                <table cellpadding="0" cellspacing="0" class="auto-style9">
                                    <tr>
                                        <td class="auto-style10">
                                            <div id="anc">
                                                 <!--公告部分-->
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style12" bgcolor="White">
                                            <div id="ct" class="chat">
                                                <!--聊天部分-->
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style13" bgcolor="White">
                                            <input type="text" id="sendTextBox" onkeypress="BindEnter(event)" onfocus="SetToEnd(this)" autofocus="autofocus" />
                                            <a href=# onclick="InsertBq()" style="font-size: 14pt">插入表情</a>
                                            颜色：<asp:DropDownList ID="DropDownList1" runat="server">
                                                <asp:ListItem Selected="True" Value="black">黑色</asp:ListItem>
                                                <asp:ListItem Value="red">红色</asp:ListItem>
                                                <asp:ListItem Value="yellow">黄色</asp:ListItem>
                                                <asp:ListItem Value="blue">蓝色</asp:ListItem>
                                                <asp:ListItem Value="green">绿色</asp:ListItem>
                                                <asp:ListItem Value="gray">灰色</asp:ListItem>
                                            </asp:DropDownList>
                                            &nbsp;
                                            <img id="sendmsg" src="Image/sendbutton.png" onclick="SendMsg()" />
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </td>
                </tr>
                <!-- part II -->
                <tr>
                    <td class="auto-style6" style="width:40%">
                        <div id="left" class="auto-style5">
                            <div class="flist">
                                <asp:Literal ID="flstLiteral" runat="server"></asp:Literal>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
