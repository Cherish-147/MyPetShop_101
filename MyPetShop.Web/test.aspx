<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <%--AllowPaging:是否允许分页--%>
<%--AllowSorting:是否排序--%>
    <%--AutoGenerateColumns：是否自动生成字段--%>
    <%--DataSourceID="Linqpro" 关联linq数据源--%>
    <%--DataKeyNames="ProductId" 绑定主键--%>
    <%--PageSize="5"每一页默认显示5条记录--%>
    <%--OnRowDataBound 绑定行页面的响应事件--%>
    <asp:GridView ID="gvproduct" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
        DataSourceID="Linqpro" DataKeyNames="ProductId" PageSize="5" OnRowDataBound="gvproduct_RowDataBound" Width="87px">
        <Columns>
            <asp:BoundField DataField="ProductId" HeaderText="商品编号" InsertVisible="False" ReadOnly="True" SortExpression="ProductId" />
            <asp:BoundField DataField="Qty" HeaderText="数量" SortExpression="Qty" /><%--在控件编辑那搞，一列一列搞--%>
            <asp:BoundField DataField="Image" HeaderText="图片" />
            <asp:BoundField DataField="Name" HeaderText="名字" SortExpression="Name" />
            <asp:ImageField DataImageUrlField="Image" HeaderText="图骗">
                <HeaderStyle Height="25px" Width="35px" />
            </asp:ImageField>
        </Columns>
        <PagerSettings FirstPageText="首页" LastPageText="尾页" Mode="NextPreviousFirstLast" NextPageText="下一页" PreviousPageText="上一页" />
    </asp:GridView>
    <asp:LinqDataSource ID="Linqpro" runat="server" ContextTypeName="MyPetShop.DAL.MyPetShopDataContext" EntityTypeName="" TableName="Product"></asp:LinqDataSource><%--gridview 加上linq,再页面绑定数据--%>

    <%--AutoPostBack="true"事件自动提交--%>
    <%--OnSelectedIndexChanged 点击下拉列表框，添加这个响应事件--%>
    每页显示
    <asp:DropDownList ID="ddlPagesize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPagesize_SelectedIndexChanged">
        <asp:ListItem>5</asp:ListItem><%--下拉列表框页码，第一个5是前端，第二个5是后端，在设计那搞--%>
        <asp:ListItem>2</asp:ListItem>
    </asp:DropDownList>
    条记录&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblmsg" runat="server" Text="Label"></asp:Label>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

