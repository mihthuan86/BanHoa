<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ChiTiet.aspx.cs" Inherits="WebBanHoa.ChiTiet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .center{
            padding-top:20px;
        }
        .hinhanh{
            width:auto;
            height:auto;
            float:left;
            border-radius:1px;
        }
        .hinh{
            width:100px;
            height:150px;
            text-align:center;
        }
        .data2{
            padding-left:10px;
            width:auto;
            height:auto;
            float:right;
        }
        .tensp{
            font-size:20px;
            font-weight:bold;
        }
        .mota{
            font-size:18px;
        }
        .gia{
            color:red;
            cursor:pointer;
        }
        .btn{
            float:left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Chi tiết sản phẩm bạn chọn phía dưới
    <asp:DataList ID="DataList2" runat="server" RepeatColumns="5">
        <ItemTemplate>
            <div class="center">
                <div class="hinhanh">
                    <asp:Image CssClass="hinh" ID="Image1" runat="server" ImageUrl='<%# "~/images/" + Eval("HinhAnh") %>' />
                </div>
                <div class="data2">
                    <asp:Label CssClass="tensp" ID="Label1" runat="server" Text='<%# Eval("TenHoa") %>'></asp:Label>
                    <br />
                    <asp:Label CssClass="mota" ID="Label3" runat="server" Text='<%#Eval("MoTa")%>'></asp:Label>
                    <br />
                    <asp:Label CssClass="gia" ID="Label2" runat="server" Text='<%#Eval("DonGia","{0:0,0}") + " VND" %>'></asp:Label>
                    <br />
                    <div class="btn">
                        <asp:Button ID="Button1" runat="server" Text="Mua" CommandArgument='<%#Eval("MaHoa") %>' OnClick="Button1_Click"/>
                        <asp:Button ID="Button2" runat="server" Text="Xem giỏ hàng" />
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
