<%@ Page Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true" CodeFile="QuanlyNamHoc.aspx.cs" Inherits="Admin_QuanlyNamHoc" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">
        .style9
        {
            text-align:center;
        }
           .style10
         {
            text-align:center;
            width:80px;
         }
        .style13
        {
           width: 700px;
            margin-top: 0px;
            text-align:center;
        }
        .style14
        {
            font-size: large;
            font-weight: bold;
            color: #FFFFFF;
        }
        .style18
        {
            font-size: 22pt;
            font-weight: bold;
            color: #0000FF;
        }
        .style1
        {
           text-align:right;
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
        </style>
    <p class="style18" style="text-align: center">
        Quản lý năm học</p>
    <table align="center" class="style9">
        <tr>
            <td style="text-align: center">
                <asp:DropDownList ID="ddltim" runat="server" Height="25px">
                    <asp:ListItem Value="MaNam">Tìm theo mã năm</asp:ListItem>
                    <asp:ListItem Value="NamHoc">Tìm theo tên năm học</asp:ListItem>
                </asp:DropDownList>
                &nbsp; <asp:TextBox ID="txttim" runat="server" Height="25px" Width="148px"></asp:TextBox>
                &nbsp;
                <asp:ImageButton ID="btntim" runat="server" ImageUrl="~/Images/Search.png" />
                
                </td>
        </tr>
    </table>
    <br />
                <br />
    <div align =center>
                        <asp:GridView ID="gvnamhoc" runat="server" AllowPaging="True" 
                        AutoGenerateColumns="False" CellPadding="4" CssClass="style13" 
                        DataKeyNames="Mã năm" ForeColor="#333333" GridLines="None" 
                        ShowFooter="True" Width="698px" Height="267px" 
                            onpageindexchanging="gvnamhoc_PageIndexChanging" 
                            onrowcancelingedit="gvnamhoc_RowCancelingEdit" 
                            onrowdeleting="gvnamhoc_RowDeleting" onrowediting="gvnamhoc_RowEditing" 
                            onrowupdating="gvnamhoc_RowUpdating" 
                            onselectedindexchanged="gvnamhoc_SelectedIndexChanged">
                        <RowStyle BackColor="#E3EAEB" />
                        <Columns>
                            <asp:TemplateField HeaderText="Mã năm" InsertVisible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblmanam" runat="server" CssClass="style9" 
                                        Text='<%# Eval("Mã năm") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="Label2" runat="server" CssClass="style9" Text="Nhập năm học :"></asp:Label>
                                    <br />
                                </FooterTemplate>
                                <ControlStyle CssClass="style9" Width="100px" />
                                <FooterStyle CssClass="style9" />
                                <HeaderStyle CssClass="style9" Width="100px" />
                                <ItemStyle CssClass="style9" Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Năm học">
                                <ItemTemplate>
                                    <asp:Label ID="lbltennam" runat="server" CssClass="style9" 
                                        Text='<%# Eval("Năm học") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txttennam" runat="server" CssClass="style10" 
                                        Text='<%# Eval("Năm học") %>' Width="70px" Height="20px"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="va1" runat="server" 
                                        ControlToValidate="txttennam" ErrorMessage="*" ValidationGroup="vaa1" 
                                        CssClass="style1" Display="Dynamic" Height="12px"></asp:RequiredFieldValidator>
                                                                        <br />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    &nbsp;
                                    <asp:TextBox ID="txttennam_them" runat="server" CssClass="style9" Width="100px"></asp:TextBox>
                                    &nbsp;
                                    <asp:RequiredFieldValidator ID="revaltxttento_them" runat="server" 
                                        ControlToValidate="txttennam_them" ErrorMessage="*" ValidationGroup="va1" 
                                        Display="Dynamic" CssClass="style1"></asp:RequiredFieldValidator>
                                </FooterTemplate>
                                <ControlStyle CssClass="style9" Width="150px" />
                                <FooterStyle CssClass="style9" />
                                <HeaderStyle CssClass="style9" Width="150px" />
                                <ItemStyle CssClass="style9" Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnsua" runat="server" CommandName="Edit">Sửa</asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="lbtnxoa" runat="server" CommandName="Delete" 
                                        onclientclick="return confirm(&quot;Bạn có chắc chắn muốn xóa??&quot;);">Xóa</asp:LinkButton>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:LinkButton ID="lbtnlu" runat="server" CommandName="Update" 
                                        ValidationGroup="vaa1">Lưu</asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="lbtnhuy" runat="server" CommandName="Cancel" 
                                        CssClass="style9">Hủy</asp:LinkButton>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    &nbsp;
                                    <asp:LinkButton ID="lbtnthem" runat="server" CssClass="style9" 
                                        ValidationGroup="va1" onclick="lbtnthem_Click">Thêm</asp:LinkButton>
                                </FooterTemplate>
                                <ControlStyle Width="100px" />
                                <FooterStyle Width="100px" />
                                <HeaderStyle Width="100px" />
                                <ItemStyle Width="100px" />
                            </asp:TemplateField>
                            <asp:CommandField HeaderText="Chi tiết" SelectText="Chi tiết" 
                                ShowSelectButton="True">
                                <ControlStyle Width="100px" />
                            </asp:CommandField>
                        </Columns>
                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                        <EmptyDataTemplate>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </EmptyDataTemplate>
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" 
                            HorizontalAlign="Center" />
                        <EditRowStyle BackColor="#7C6F57" HorizontalAlign="Center" Height="24px" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                </div>

    <p>
    <br />
        <asp:MultiView ID="MultiView2" runat="server">
            <asp:View ID="View2" runat="server">
                <table align="center" class="style13">
                    <tr>
                        <td class="style14" style="text-align: center; background-color: #0000FF" 
                            width="650px">
                            Thông tin năm học</td>
                    </tr>
                    <tr>
                        <td align="center" style="text-align: center">
                        <div align=center>
                            <asp:GridView ID="dthk" runat="server" BackColor="White" BorderColor="#3366CC" 
                                BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="600px">
                                <RowStyle BackColor="White" ForeColor="#003399" CssClass="style9" />
                                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                            </asp:GridView>
                            </div>
                        </td>
                    </tr>
                </table>
            </asp:View>
        </asp:MultiView>
</p>
    </asp:Content>



