<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SanPham.aspx.cs" Inherits="WebBanHoa.SanPham" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .data{
            width:200px;
            height:250px;
            display:inline-block;
            float:left;
            padding-bottom:10px;
        }
        .hinh{
            width:150px;
            height:150px;
        }
        .tenhoa{
            margin-top:10px;
            text-decoration:underline;
            font-size:15px;
            font-weight:bold;
        }
        .gia{
            margin-top:10px;
            text-decoration:underline;
            font-size:15px;
            font-weight:bold;
        }
        .btnChiTiet{
            margin-top:10px;
            color:blueviolet;
            cursor:pointer;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Danh Mục Sản Phẩm Bạn Chọn
    <asp:DataList ID="DataList1" runat="server" RepeatColumns="5">
        <ItemTemplate>
            <div class="data">
                <asp:Image ID="Image1" CssClass="hinh" runat="server" ImageUrl='<%# "~/images/" + Eval("HinhAnh") %>' />
                <br />
                <asp:LinkButton CssClass="btnChiTiet" ID="LinkButton1" runat="server" Text='<%#"Tên hoa : " + Eval("TenHoa")%>' CommandArgument='<%# Eval("MaHoa") %>' OnClick="LinkButton1_Click"></asp:LinkButton>
                <br />
                <asp:LinkButton CssClass="btnChiTiet" ID="LinkButton2" runat="server" Text='<%#"Giá : " + Eval("DonGia","{0:0,0}") + "VND" %>' CommandArgument='<%# Eval("MaHoa") %>' OnClick="LinkButton1_Click"></asp:LinkButton>
            </div>    
        </ItemTemplate>
    </asp:DataList>

</asp:Content>
