<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sample_OCR.aspx.cs" Inherits="openCV_Sample.sample_OCR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="labResule" runat="server" Text=""></asp:Label>
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <br />
            <asp:Button ID="Button1" runat="server" Text="光學辨認" OnClick="Button1_Click" />
            <br />
            <textarea id="outPutTbArea" cols="20" rows="2" runat="server"></textarea>
        </div>
    </form>
</body>
</html>
