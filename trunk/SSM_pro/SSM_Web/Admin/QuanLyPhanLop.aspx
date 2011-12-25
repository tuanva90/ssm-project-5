<%@ Page Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true" CodeFile="QuanLyPhanLop.aspx.cs" Inherits="Admin_QuanLyPhanLop" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">
        .style18
        {
            font-size: 22pt;
            font-weight: bold;
            color: #0000FF;
        }
        .style9
        {
        	text-align:center;
        }
                    
.dxeButtonEdit
{
    background-color: white;
    border: solid 1px #9F9F9F;
    width: 170px;
}
        
.dxeButtonEdit
{
    background-color: white;
    border: solid 1px #9F9F9F;
    width: 170px;
}

.dxeEditArea 
{
	font-family: Tahoma;
	font-size: 9pt;
	border: 1px solid #A0A0A0;
}

.dxeEditArea 
{
	font-family: Tahoma;
	font-size: 9pt;
	border: 1px solid #A0A0A0;
}
.dxeButtonEditButton,
.dxeSpinIncButton, .dxeSpinDecButton, .dxeSpinLargeIncButton, .dxeSpinLargeDecButton
{
    padding: 0px 2px 0px 3px;
	    background-repeat: repeat-x;
    background-position: top;    
    background-color: #e6e6e6;
}
.dxeButtonEditButton, .dxeCalendarButton,
.dxeSpinIncButton, .dxeSpinDecButton,
.dxeSpinLargeIncButton, .dxeSpinLargeDecButton
{	
	vertical-align: middle;
	border: solid 1px #7f7f7f;
	cursor: pointer;
	cursor: hand;
} 
.dxeButtonEditButton
{	
	vertical-align: middle;
	border: solid 1px #7f7f7f;
	cursor: pointer;
	cursor: hand;
} 
        .dxeButtonEditButton
{
    padding: 0px 2px 0px 3px;
	    background-repeat: repeat-x;
    background-position: top;    
    background-color: #e6e6e6;
}
        .style13
        {
           width: 700px;     
           font-size:12pt;       
        }
        </style>
    <p style="text-align: center">
        &nbsp;</p>
             <p class="style18" style="text-align: center; height: 4px;" 
        __designer:mapid="8e">
                 Danh sách học sinh chưa được phân lớp</p>
            <p>
                &nbsp;</p>
    <p>
                                <asp:DropDownList ID="ddnamhoc" runat="server" Height="25px" 
                                    AutoPostBack="True" DataSourceID="SqlDataSource2" DataTextField="Năm học" 
                                    DataValueField="Mã năm" onselectedindexchanged="ddnamhoc_SelectedIndexChanged" 
                                    Width="100px">
                                </asp:DropDownList>
    </p>
    <p>
                                <asp:Label ID="lblinfor" runat="server" Font-Bold="True" Font-Size="Medium" 
                                    ForeColor="Black" Text="Label"></asp:Label>
    </p>
    <div align = center>
                    <asp:GridView ID="gvhocsinh" runat="server" AllowPaging="True" 
                        AutoGenerateColumns="False" CellPadding="4" CssClass="style13" 
                        ForeColor="#333333" GridLines="None" 
                        onselectedindexchanged="gvhocsinh_SelectedIndexChanged" ShowFooter="True" 
                        Width="600px" HorizontalAlign="Center" 
                        onpageindexchanging="gvhocsinh_PageIndexChanging">
                        <RowStyle BackColor="#E3EAEB" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="ckchon" runat="server" />
                                </ItemTemplate>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="ckall" runat="server" AutoPostBack="True" 
                                        oncheckedchanged="ckall_CheckedChanged" />
                                </HeaderTemplate>
                                <ControlStyle Width="30px" />
                                <ItemStyle Width="30px" CssClass="style9" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Mã học sinh" InsertVisible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblmahs" runat="server" CssClass="style9" 
                                        Text='<%# Eval("Mã HS") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="Label5" runat="server" Text="Phân vào lớp :"></asp:Label>
                                    <br />
                                </FooterTemplate>
                                <ControlStyle CssClass="style9" Width="110px" />
                                <FooterStyle CssClass="style9" />
                                <HeaderStyle CssClass="style9" Width="100px" />
                                <ItemStyle CssClass="style9" Width="110px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Họ tên">
                                <ItemTemplate>
                                    <asp:Label ID="lblhoten" runat="server" CssClass="style9" 
                                        Text='<%# Eval("Họ tên") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <br />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    &nbsp; &nbsp;
                                    <asp:DropDownList ID="ddllop" runat="server" DataSourceID="SqlDataSource4" 
                                        DataTextField="TenLop" DataValueField="MaLop">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:SSMDBConnectionString %>" 
                                        SelectCommand="SELECT [MaLop], [TenLop] FROM [LOP]"></asp:SqlDataSource>
                                </FooterTemplate>
                                <ControlStyle CssClass="style9" Width="300px" />
                                <FooterStyle CssClass="style9" />
                                <HeaderStyle CssClass="style9" Width="300px" />
                                <ItemStyle CssClass="style9" Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Chức vụ">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlchucvu" runat="server" DataSourceID="SqlDataSource3" 
                                        DataTextField="ChucVu" DataValueField="MaCV" Height="22px">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:SSMDBConnectionString %>" 
                                        SelectCommand="SELECT [MaCV], [ChucVu] FROM [CHUCVU]"></asp:SqlDataSource>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:LinkButton ID="lblthemvaolop" runat="server" onclick="lblthemvaolop_Click">Lưu</asp:LinkButton>
                                </FooterTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle Width="100px" />
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                        <EmptyDataTemplate>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </EmptyDataTemplate>
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" 
                            HorizontalAlign="Center" />
                        <EditRowStyle BackColor="#7C6F57" HorizontalAlign="Center" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                 </div>
                 </br>
                </br>
    <p>
        <asp:MultiView ID="MultiView3" runat="server">
            <asp:View ID="View3" runat="server">
            <div align="center">
                <div align="center">
                </div>
                </div>
            </asp:View>
            <br />
        </asp:MultiView>
    </p>
    <p>
        &nbsp;</p>
</asp:Content>







