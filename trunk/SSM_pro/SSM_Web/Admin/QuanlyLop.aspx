<%@ Page Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true" CodeFile="QuanlyLop.aspx.cs" Inherits="Admin_QuanlyLop" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">
        .style9
        {  
            text-align: center;
         }
        .style13
        {
           width: 700px;     
           font-size:12pt;       
        }
        .style18
        {
            font-size: 22pt;
            font-weight: bold;
            color: #0000FF;
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
    <p style="text-align: center">
        &nbsp;</p>
             <p class="style18" style="text-align: center" __designer:mapid="8e">
                 Khối lớp</p>
            <p>
        <asp:MultiView ID="MultiView2" runat="server">
            <asp:View ID="View2" runat="server">
                <div align="center">
                    <br />
                    <table align="center" class="style9">
                        <tr>
                            <td style="text-align: center">
                                <asp:DropDownList ID="ddltim" runat="server" Height="25px">
                                    <asp:ListItem Value="MaTo">Tìm theo mã tổ</asp:ListItem>
                                    <asp:ListItem Value="TenTo">Tìm theo tên tổ</asp:ListItem>
                                </asp:DropDownList>
                                &nbsp;
                                <asp:TextBox ID="txttim" runat="server" Height="25px" Width="148px"></asp:TextBox>
                                &nbsp;
                                <asp:ImageButton ID="btntim" runat="server" Height="16px" 
                                    ImageUrl="~/Images/Search.png" Width="25px" />
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="gvkhoilop" runat="server" AllowPaging="True" 
                        AutoGenerateColumns="False" CellPadding="4" CssClass="style13" 
                        DataKeyNames="Mã khối" ForeColor="#333333" GridLines="None" 
                        onselectedindexchanged="gvkhoilop_SelectedIndexChanged" ShowFooter="True" 
                        Width="700px">
                        <RowStyle BackColor="#E3EAEB" />
                        <Columns>
                            <asp:TemplateField HeaderText="Mã khối lớp" InsertVisible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblmakhoi" runat="server" CssClass="style9" 
                                        Text='<%# Eval("Mã khối") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <br />
                                </FooterTemplate>
                                <ControlStyle CssClass="style9" Width="100px" />
                                <FooterStyle CssClass="style9" />
                                <HeaderStyle CssClass="style9" Width="100px" />
                                <ItemStyle CssClass="style9" Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tên khối lớp">
                                <ItemTemplate>
                                    <asp:Label ID="lbltenkhoi" runat="server" CssClass="style9" 
                                        Text='<%# Eval("Tên khối") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <br />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    &nbsp; &nbsp;
                                </FooterTemplate>
                                <ControlStyle CssClass="style9" Width="200px" />
                                <FooterStyle CssClass="style9" />
                                <HeaderStyle CssClass="style9" Width="300px" />
                                <ItemStyle CssClass="style9" Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Số lớp">
                                <ItemTemplate>
                                    <asp:Label ID="lblsolop" runat="server" Text='<%# Eval("Số lớp") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField SelectText="Thông tin lớp" ShowSelectButton="True" />
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
                    <br />
                </div>
            </asp:View>
        </asp:MultiView>
    </p>
    </br>
                </br>
    <p class="style18" style="text-align: center">
        &nbsp;</p>
    <p>
        <asp:MultiView ID="MultiView3" runat="server" 
            onactiveviewchanged="MultiView3_ActiveViewChanged">
            <asp:View ID="View3" runat="server">
            <div align="center">
                <div align="center">
                    <asp:GridView ID="gvlop" runat="server" AllowPaging="True" 
                        AutoGenerateColumns="False" CellPadding="4" CssClass="style13" 
                        DataKeyNames="Mã lớp" ForeColor="#333333" GridLines="None" 
                        onpageindexchanging="gvlop_PageIndexChanging" 
                        onrowcancelingedit="gvlop_RowCancelingEdit" onrowdeleting="gvlop_RowDeleting" 
                        onrowediting="gvlop_RowEditing" onrowupdating="gvlop_RowUpdating" 
                        onselectedindexchanged="gvlop_SelectedIndexChanged" ShowFooter="True" 
                        Width="800px">
                        <RowStyle BackColor="#E3EAEB" />
                        <Columns>
                            <asp:TemplateField HeaderText="Mã lớp" InsertVisible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lbtnmalop" runat="server" CssClass="style9" 
                                        Text='<%# Eval("Mã lớp") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="Label3" runat="server" CssClass="style9" Text="Nhập tên lớp :"></asp:Label>
                                    <br />
                                </FooterTemplate>
                                <ControlStyle CssClass="style9" Width="100px" />
                                <FooterStyle CssClass="style9" />
                                <HeaderStyle CssClass="style9" Width="200px" />
                                <ItemStyle CssClass="style9" Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tên lớp">
                                <ItemTemplate>
                                    <asp:Label ID="lbltenlop" runat="server" CssClass="style9" 
                                        Text='<%# Eval("Tên lớp") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txttenlop" runat="server" CssClass="style9" 
                                        Text='<%# Eval("Tên lớp") %>' Width="100px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                        ControlToValidate="txttenlop" CssClass="style1" Display="Dynamic" 
                                        ErrorMessage="*" ValidationGroup="val4"></asp:RequiredFieldValidator>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    &nbsp;
                                    <asp:TextBox ID="txttenlop_them" runat="server" CssClass="style9" Width="100px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="revaltxttenmon_them" runat="server" 
                                        ControlToValidate="txttenlop_them" CssClass="style1" ErrorMessage="*" 
                                        ValidationGroup="va2"></asp:RequiredFieldValidator>
                                </FooterTemplate>
                                <ControlStyle CssClass="style9" Width="200px" />
                                <FooterStyle CssClass="style9" />
                                <HeaderStyle CssClass="style9" Width="300px" />
                                <ItemStyle CssClass="style9" Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sĩ số">
                                <ItemTemplate>
                                    <asp:Label ID="lblsiso" runat="server" Text='<%# Eval("Sĩ số") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="GV CN">
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("GVCN") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlgvcn" runat="server" CssClass="style9" 
                                        DataSource="<%# GetGV() %>" DataTextField="Họ tên" DataValueField="Mã GV" 
                                        SelectedIndex='<%# GetMaGV_index((string)DataBinder.Eval(Container.DataItem, "GVCN")) %>'>
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:DropDownList ID="ddlgvcn_them" runat="server" DataTextField="Họ tên" 
                                        DataValueField="Mã GV">
                                    </asp:DropDownList>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton6" runat="server" CommandName="Edit">Sửa</asp:LinkButton>
                                    &nbsp;&nbsp;
                                    <asp:LinkButton ID="LinkButton7" runat="server" CommandName="Delete" 
                                        onclientclick="return confirm(&quot;Bạn có chắc chắn muốn xóa?&quot;);">Xóa</asp:LinkButton>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:LinkButton ID="LinkButton8" runat="server" CommandName="Update" 
                                        ValidationGroup="val4">Lưu</asp:LinkButton>
                                    &nbsp;
                                    <asp:LinkButton ID="LinkButton9" runat="server" CommandName="Cancel">Hủy</asp:LinkButton>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    &nbsp;
                                    <asp:LinkButton ID="lbtnthemmon" runat="server" CssClass="style9" 
                                        onclick="lbtnthemmon_Click" ValidationGroup="va2">Thêm</asp:LinkButton>
                                </FooterTemplate>
                                <ControlStyle CssClass="style9" />
                                <FooterStyle CssClass="style9" />
                                <HeaderStyle Width="200px" />
                                <ItemStyle CssClass="style9" Width="200px" />
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
                </div>
            </asp:View>
            <br />
        </asp:MultiView>
    </p>
    <p>
        &nbsp;</p>
</asp:Content>





