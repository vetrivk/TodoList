<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TodoList.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <%--bootstrap css link--%>
  <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
  <style>
      .to-container{
         width:70%;
          margin: 0 auto;
          height: 100vh;
          display:flex;
          justify-content:center;
          align-items:center;
      }
      .to-con{
          width:600px;
           display:flex;
 justify-content:center;
 align-items:center;
      }
  </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">

            <div class="to-container">
                <div>
                    <div>
                        <h3>To do list </h3>
                    </div>
                    <div class="to-con ">
                        <asp:TextBox placeholder="login Email" CssClass="form-control me-3" ID="txtLogin" runat="server"></asp:TextBox>
                        <asp:Button CssClass="btn btn-primary" ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
