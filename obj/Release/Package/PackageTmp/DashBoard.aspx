<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DashBoard.aspx.cs" Inherits="TodoList.DashBoard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Todo list</title>
    <%--bootstrap css link--%>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
    <style>
        .todolist {
            width: 70%;
            margin: 20px auto;
        }
        .todo-item {
            display: flex;
            align-items: center;
            justify-content: space-between;
            padding: 10px;
            border-bottom: 1px solid #ddd;
        }
        .todo-item:nth-child(even) {
            background-color: #f9f9f9;
        }
        .todo-item .details {
            flex-grow: 1;
            margin-right: 10px;
        }
    </style>
</head>
<body>

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div class="container">
            <header class="mt-5">
                <h2>welcome <asp:Label ID="lblWelcome" runat="server" Text="Label"></asp:Label> </h2>
                <p>Pending :
                    <asp:Label ID="lblPending" runat="server" Text="0"></asp:Label>
                </p>
                <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" />
               
            </header>
            <div class="todolist ">
                <div class="row row-cols-lg-3">
                    <div class="col">
                        <asp:TextBox placeholder="Daily Task" CssClass="form-control" ID="txtInput" runat="server"></asp:TextBox>
                    </div>
                    <div class="col">
                        <asp:TextBox CssClass="form-control" type="date" ID="txtDate" runat="server"></asp:TextBox>
                    </div>


                    <div class="col">
                        <asp:Button CssClass="btn btn-primary" ID="btnSubmit" runat="server" Text="Button" OnClick="btnSubmit_Click" />
                    </div>

                </div>
            </div>
            <div class="mt-5">       
                
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">

                    <ItemTemplate >
                        <div class="todo-item todolist">
                            <div class="details">
                                <div class="row row-cols-lg-3">
                                  
                                     <div class="col"><%# Eval("item") %></div>
                                     <div class="col"><%# Eval("dataItem", "{0:yyyy-MM-dd}") %></div>
                                </div>
                                                       
                            </div>
                            <asp:Button ID="btnDelete" runat="server" CommandName="DeleteItem" CommandArgument='<%# Eval("itemId") %>' Text="Delete" CssClass="btn btn-danger" />
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
            </ContentTemplate>
</asp:UpdatePanel>
    </form>

    <%--bootstrap js link--%>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</body>
</html>
