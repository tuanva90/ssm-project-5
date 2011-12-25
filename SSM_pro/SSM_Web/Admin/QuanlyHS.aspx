<%@ Page Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true" CodeFile="QuanlyHS.aspx.cs" Inherits="Admin_Default2" Title="Untitled Page" %>
<%@ Register namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">
        .style9
        {
            width: 70%;
        }
        .style13
        {
           width: 700px;            
        }
        .style14
        {
            font-size: large;
            font-weight: bold;
            color: #FFFFFF;
        }
        .style15
        {
            width: 700px;
        }
        .style16
        {
            font-size: 16pt;
            color: white;
        }
        .style17
        {
            width: 145px;
            font-weight: bold;
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
    <p class="style18" style="text-align: center">
        Quản lý học sinh</p>
    <table align="center" class="style9">
        <tr>
            <td style="text-align: center">
                <asp:DropDownList ID="ddltim" runat="server" Height="25px">
                    <asp:ListItem Value="MaHS">Tìm theo mã học sinh</asp:ListItem>
                    <asp:ListItem Value="HoTen">Tìm theo tên học sinh</asp:ListItem>
                </asp:DropDownList>
                &nbsp; <asp:TextBox ID="txttim" runat="server" Height="25px" Width="148px"></asp:TextBox>
                &nbsp;
                <asp:ImageButton ID="btntim" runat="server" ImageUrl="~/Images/Search.png" 
                    onclick="btntim_Click" />
                </td>
        </tr>
    </table>
    <p style="text-align: center">
        <asp:Button ID="btnAddNew" runat="server" onclick="btnAddNew_Click" 
            Text="Thêm mới học sinh" Width="178px" CausesValidation="False" />
    </p>
    <p align="center">
             <div align="center">
                   <asp:GridView ID="gvdshs" runat="server" CellPadding="4" 
            DataKeyNames="Mã HS" Width="700px" AllowPaging="True" 
            onselectedindexchanged="gvdshs_SelectedIndexChanged" CssClass="style13" 
                       onpageindexchanging="gvdshs_PageIndexChanging" ForeColor="#333333" 
                       GridLines="None">
            <RowStyle BackColor="#E3EAEB" />
            <Columns>
                <asp:CommandField SelectText="Chi tiết" ShowSelectButton="True" 
                    DeleteText="Xóa" EditText="Sửa" >
                    <ItemStyle Width="50px" />
                </asp:CommandField>
            </Columns>
            <FooterStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" 
                HorizontalAlign="Center" />
            <EditRowStyle HorizontalAlign="Center" BackColor="#7C6F57" />
                       <AlternatingRowStyle BackColor="White" />
           </asp:GridView>
           </div>
    </p>
    <p>
    <br />
        <asp:MultiView ID="MultiView2" runat="server">
            <asp:View ID="View2" runat="server">
                <table align="center" class="style13">
                    <tr>
                        <td class="style14" style="text-align: center; background-color: #0000FF" 
                            width="650px">
                            Thông tin học sinh</td>
                    </tr>
                    <tr>
                        <td align="center" style="text-align: center">
                            <asp:DetailsView ID="dths" runat="server" CellPadding="4" 
                                ForeColor="#333333" GridLines="None" Height="50px" style="text-align: center" 
                                Width="700px">
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
                                <RowStyle BackColor="#EFF3FB" />
                                <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <Fields>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            &nbsp;&nbsp;<asp:LinkButton ID="lbtnEdit" runat="server" onclick="lbtnEdit_Click">Edit</asp:LinkButton>
                                            &nbsp;&nbsp;
                                            <asp:LinkButton ID="lbtnDelete" runat="server" onclick="lbtnDelete_Click" 
                                                onclientclick="return confirm(&quot;Are you sure Delete?&quot;);">Delete</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Fields>
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#2461BF" />
                                <AlternatingRowStyle BackColor="White" />
                            </asp:DetailsView>
                        </td>
                    </tr>
                </table>
            </asp:View>
        </asp:MultiView>
</p>
    <p>
        <asp:MultiView ID="MultiView3" runat="server">
            <asp:View ID="View3" runat="server">
                <table align="center" class="style15">
                    <tr>
                        <td align="center" bgcolor="Blue" class="style16" colspan="2">
                            Sửa thông tin học sinh</td>
                    </tr>
                    <tr>
                        <td class="style17">
                            Mã HS :</td>
                        <td>
                            <asp:Label ID="lblmahs" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style17">
                            Họ tên :</td>
                        <td>
                            <asp:TextBox ID="txthoten" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style17">
                            <asp:Label ID="Label8" runat="server" Text="Giới tính : "></asp:Label>
                        </td>
                        <td>
                            <asp:CheckBox ID="ckbgioitinh" runat="server" Text="Nam" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style17">
                            Địa chỉ</td>
                        <td>
                            <asp:TextBox ID="txtdiachi" runat="server" Width="200px" Height="80px" 
                                TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style17">
                            <asp:Label ID="Label2" runat="server" Text="Số điện thoại :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtsodienthoai" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style17">
                            <asp:Label ID="Label3" runat="server" Text="Họ tên cha :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txthotencha" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style17">
                            <asp:Label ID="Label4" runat="server" Text="Nghề nghiệp cha :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtnghenghiepcha" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style17">
                            <asp:Label ID="Label5" runat="server" Text="Họ tên mẹ :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txthotenme" runat="server" Width="199px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style17">
                            <asp:Label ID="Label6" runat="server" Text="Nghề nghiệp mẹ :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtnghenghiepme" runat="server" Width="197px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style17">
                            <asp:Label ID="Label7" runat="server" Text="Ngày sinh :"></asp:Label>
                        </td>
                        <td align="center" class="style17">
                         
                            <dxe:ASPxDateEdit ID="txtDate" runat="server" Width="180px">
                            </dxe:ASPxDateEdit>
                         
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Button ID="btnUpdate" runat="server" onclick="btnUpdate_Click" 
                                Text="Update" Width="114px" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnCancel" runat="server" CausesValidation="False" 
                                onclick="btnCancel_Click" Text="Cancel" Width="129px" />
                            <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">LinkButton</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </asp:View>
            <br />
        </asp:MultiView>
    </p>
    <p>
        &nbsp;</p>
</asp:Content>

