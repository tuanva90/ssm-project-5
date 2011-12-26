<%@ Page Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true" CodeFile="ThemHocSinh.aspx.cs" Inherits="Admin_QLHocSinh" Title="Untitled Page" %>
<%@ Register namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">
        .style7
        {
            width: 15%;
            text-align: left;
        }
        
        .style8
        {       
        
        }
        .style10
        {
            width: 250px;
            
        }
        .style11
        {
            height: 30px;
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
.dxeButtonEditButton,
.dxeSpinIncButton, .dxeSpinDecButton, .dxeSpinLargeIncButton, .dxeSpinLargeDecButton
{
    padding: 0px 2px 0px 3px
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
        </style>
        <p>
        <br />
                 </p>
      <td align=center>
       <p>
        <br /> 
             
         </p>
    <asp:Panel ID="Panel1" runat="server" Height="722px" 
        GroupingText="Thêm học sinh" Width="900px" HorizontalAlign="Center" 
        CssClass="style8">
        <table align="center" style="width: 100%; height: 432px;" class="style7">
            <tr>
                <td class="style7">
                    &nbsp;</td>
                <td class="style7">
                    &nbsp;</td>
                <td class="style7">
                    &nbsp;</td>
                <td class="style7">
                    &nbsp;</td>
                <td class="style7">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: left">
                    <asp:Label ID="Label14" runat="server" Text="Mã HS :"></asp:Label>
                </td>
                <td>
                    &nbsp;
                    <asp:TextBox ID="txtmahs" runat="server" AutoPostBack="True" 
                        ontextchanged="txtmahs_TextChanged1" Width="35px"></asp:TextBox>
                    <asp:Label ID="lblmahs" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td rowspan="3">
                    <asp:Label ID="Label5" runat="server" Text="Địa chỉ :"></asp:Label>
                </td>
                <td rowspan="3" ID="txtd">
                    <asp:TextBox ID="txtdiachi" runat="server" Height="71px" TextMode="MultiLine" 
                        Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: left">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: left">
                    <asp:Label ID="Label13" runat="server" Text="Họ tên :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txthoten" runat="server"></asp:TextBox>
                </td>
                <td>
                    </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: left">
                    <asp:Label ID="Label12" runat="server" Text="Giới tính :"></asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="ckbgioitinh" runat="server" Text="Nam" />
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Lớp :"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddllop" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label11" runat="server" Text="Số điện thoại :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtsodienthoai" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Chức vụ :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtchucvu" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label10" runat="server" Text="Hõ tên cha :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txthotencha" runat="server" style="margin-bottom: 0px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Học kỳ :"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlhocky" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label9" runat="server" Text="Nghề nghiệp cha&nbsp; :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtnghenghiepcha" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td colspan="2" rowspan="5">
                    <asp:Panel ID="Panel2" runat="server" GroupingText="Dành cho HS lên cấp" 
                        Height="142px">
                        <asp:Panel ID="Panel3" runat="server" Height="167px">
                            <table class="style10">
                                <tr>
                                    <td class="style10">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style10">
                                        <asp:Label ID="Label15" runat="server" Text="Điểm TB :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBox1" runat="server" Width="123px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style10">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style10">
                                        <asp:Label ID="Label16" runat="server" Text="Hạnh kiểm :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBox2" runat="server" Width="124px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style10">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style10">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label8" runat="server" Text="Họ tên mẹ :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txthotenme" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="Nghề nghiệp mẹ :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtnghenghiepme" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="Ngày sinh :"></asp:Label>
                </td>
                <td>
                    <dxe:ASPxDateEdit ID="txtDate" runat="server" Width="125px">
                    </dxe:ASPxDateEdit>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;
                    </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style11">
                    </td>
                <td class="style11">
                    </td>
                <td class="style11">
                    </td>
                <td class="style11">
                    <asp:Button ID="btnluuthongtin" runat="server" onclick="btnluuthongtin_Click" 
                        Text="Lưu" />
                    &nbsp;
                    <asp:Button ID="btnhuy" runat="server" onclick="btnhuy_Click" Text="Hủy" />
                </td>
                <td class="style11">
                    </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>                
                                              
                                      
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style8">
                    &nbsp;</td>
                <td class="style8">
                    &nbsp;</td>
                <td class="style8">
                </td>
                <td class="style8">
                    &nbsp;</td>
                <td class="style8">
                    </td>
            </tr>
            <tr>
                <td class="style8">
                    &nbsp;</td>
                <td class="style8">
                    &nbsp;</td>
                <td class="style8">
                    &nbsp;</td>
                <td class="style8">
                    &nbsp;</td>
                <td class="style8">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style8">
                    &nbsp;</td>
                <td class="style8">
                    &nbsp;</td>
                <td class="style8">
                    &nbsp;</td>
                <td class="style8">
                    &nbsp;</td>
                <td class="style8">
                    &nbsp;</td>
            </tr>
        </table>
    </asp:Panel>
    </td>
    
<script language="javascript" type="text/javascript">
// <!CDATA[

function Submit1_onclick() {

}

// ]]>
</script>
</asp:Content>


