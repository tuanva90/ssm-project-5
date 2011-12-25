<%@ Page Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true" CodeFile="QuanlyTo.aspx.cs" Inherits="Admin_QuanlyTo" Title="Untitled Page" %>

<%@ Register namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>

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
        .style1
        {
        	text-align:left;
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
                 <asp:LinkButton ID="LinkButton11" runat="server" onclick="LinkButton11_Click">Quản 
                 lý tổ</asp:LinkButton>
    </p>
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
                                <asp:TextBox ID="txttim" runat="server" Height="25px" Width="148px" 
                                    ontextchanged="txttim_TextChanged"></asp:TextBox>
                                &nbsp;
                                <asp:ImageButton ID="btntim" runat="server" Height="16px" 
                                    ImageUrl="~/Images/Search.png" onclick="btntim_Click" Width="25px" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <asp:GridView ID="gvto" runat="server" AllowPaging="True" 
                        AutoGenerateColumns="False" CellPadding="4" CssClass="style13" 
                        DataKeyNames="Mã tổ" ForeColor="#333333" GridLines="None" 
                        onpageindexchanging="gvto_PageIndexChanging" 
                        onrowcancelingedit="gvto_RowCancelingEdit" onrowdeleting="gvto_RowDeleting" 
                        onrowediting="gvto_RowEditing" onrowupdating="gvto_RowUpdating" 
                        ShowFooter="True" Width="700px" 
                        onselectedindexchanged="gvto_SelectedIndexChanged1">
                        <RowStyle BackColor="#E3EAEB" />
                        <Columns>
                            <asp:TemplateField HeaderText="Mã tổ" InsertVisible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblmato" runat="server" CssClass="style9" 
                                        Text='<%# Eval("Mã tổ") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="Label2" runat="server" CssClass="style9" Text="Nhập tên tổ :"></asp:Label>
                                    <br />
                                </FooterTemplate>
                                <ControlStyle CssClass="style9" Width="200px" />
                                <FooterStyle CssClass="style9" />
                                <HeaderStyle CssClass="style9" Width="100px" />
                                <ItemStyle CssClass="style9" Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tên tổ">
                                <ItemTemplate>
                                    <asp:Label ID="lbltento" runat="server" CssClass="style9" 
                                        Text='<%# Eval("Tên tổ") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txttento" runat="server" CssClass="style9" 
                                        Text='<%# Eval("Tên tổ") %>' Width="100px" Columns="1"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="txttento" ErrorMessage="*" ValidationGroup="va3" 
                                        Display="Dynamic" CssClass="style1"></asp:RequiredFieldValidator>
                                    <br />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    &nbsp;
                                    <asp:TextBox ID="txttento_them" runat="server" CssClass="style9" Width="100px"></asp:TextBox>
                                    &nbsp;
                                    <asp:RequiredFieldValidator ID="revaltxttento_them" runat="server" 
                                        ControlToValidate="txttento_them" ErrorMessage="*" ValidationGroup="va1" 
                                        Display="Dynamic" CssClass="style1"></asp:RequiredFieldValidator>
                                </FooterTemplate>
                                <ControlStyle CssClass="style9" Width="200px" />
                                <FooterStyle CssClass="style9" />
                                <HeaderStyle CssClass="style9" Width="300px" />
                                <ItemStyle CssClass="style9" Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Edit" 
                                        onclick="LinkButton2_Click">Sửa</asp:LinkButton>
                                    &nbsp;&nbsp;
                                    <asp:LinkButton ID="LinkButton5" runat="server" CommandName="Delete" 
                                        onclientclick="return confirm(&quot;Bạn có chắc chắn muốn xóa?&quot;);">Xóa</asp:LinkButton>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Update" 
                                        ValidationGroup="va3" onclick="LinkButton3_Click">Lưu</asp:LinkButton>
                                    &nbsp;
                                    <asp:LinkButton ID="LinkButton4" runat="server" CommandName="Cancel">Hủy</asp:LinkButton>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    &nbsp;
                                    <asp:LinkButton ID="lbtnthem" runat="server" CssClass="style9" 
                                        onclick="lbtnthem_Click" 
                                        ValidationGroup="va1">Thêm</asp:LinkButton>
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
            </asp:View>
        </asp:MultiView>
    </p>
    </br>
    </br>
    <p class="style18" style="text-align: center">
        <asp:LinkButton ID="LinkButton10" runat="server" onclick="LinkButton10_Click">Quản 
        lý môn học</asp:LinkButton>
    </p>
    <p>
        <asp:MultiView ID="MultiView3" runat="server">
            <asp:View ID="View3" runat="server">
            <div align="center">
                <asp:GridView ID="gvmon" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" CellPadding="4" CssClass="style13" 
                    DataKeyNames="Mã môn" ForeColor="#333333" GridLines="None" 
                    onpageindexchanging="gvmon_PageIndexChanging" 
                    onrowcancelingedit="gvmon_RowCancelingEdit" onrowdeleting="gvmon_RowDeleting" 
                    onrowediting="gvmon_RowEditing" onrowupdating="gvmon_RowUpdating" 
                    onselectedindexchanged="gvmon_SelectedIndexChanged" ShowFooter="True" 
                    Width="800px">
                    <RowStyle BackColor="#E3EAEB" />
                    <Columns>
                        <asp:TemplateField HeaderText="Mã môn học" InsertVisible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblmamon" runat="server" CssClass="style9" 
                                    Text='<%# Eval("Mã môn") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="Label3" runat="server" CssClass="style9" 
                                    Text="Nhập tên môn học :"></asp:Label>
                                <br />
                            </FooterTemplate>
                            <ControlStyle CssClass="style9" Width="200px" />
                            <FooterStyle CssClass="style9" />
                            <HeaderStyle CssClass="style9" Width="200px" />
                            <ItemStyle CssClass="style9" Width="200px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tên môn học">
                            <ItemTemplate>
                                <asp:Label ID="lbltenmon" runat="server" CssClass="style9" 
                                    Text='<%# Eval("Tên môn") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txttenmon" runat="server" CssClass="style9" 
                                    Text='<%#Eval("Tên môn") %>' Width="100px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ControlToValidate="txttenmon" ErrorMessage="*" ValidationGroup="val4" 
                                    Text='<%# Eval("Tên môn") %>' CssClass="style1" Display="Dynamic"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <FooterTemplate>
                                &nbsp;
                                <asp:TextBox ID="txttenmon_them" runat="server" CssClass="style9" Width="100px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="revaltxttenmon_them" runat="server" 
                                    ControlToValidate="txttenmon_them" ErrorMessage="*" ValidationGroup="va2" 
                                    CssClass="style1"></asp:RequiredFieldValidator>
                            </FooterTemplate>
                            <ControlStyle CssClass="style9" Width="200px" />
                            <FooterStyle CssClass="style9" />
                            <HeaderStyle CssClass="style9" Width="300px" />
                            <ItemStyle CssClass="style9" Width="300px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Hệ số">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtheso_sua" runat="server" Text='<%# Eval("Hệ Số") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtheso_them" runat="server"></asp:TextBox>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblheso" runat="server" Text='<%# Eval("Hệ số") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton6" runat="server" CommandName="Edit" 
                                    onclick="LinkButton2_Click">Sửa</asp:LinkButton>
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
            </asp:View>
            <br />
        </asp:MultiView>
    </p>
    <p>
        &nbsp;</p>
</asp:Content>




