<%@ Page Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true"
    CodeFile="ThemHocSinh.aspx.cs" Inherits="Admin_QLHocSinh" Title="Untitled Page" %>

<%@ Register Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="Panel1" runat="server" GroupingText=""
        HorizontalAlign="Center" Height="889px" Width="700px">
        <div class="table" align="center">
            <table align="left" class="table">
            <tr>
                <td class="style20" style="background:#DEE8F5;">
                    <asp:Label ID="Label14" runat="server" Text="Mã HS"></asp:Label>
                </td>
                <td>
                    &nbsp;
                    <asp:TextBox ID="txtmahs" runat="server" AutoPostBack="True" OnTextChanged="txtmahs_TextChanged1"
                        Width="35px"></asp:TextBox>
                    <asp:Label ID="lblmahs" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style20" style="background:#DEE8F5;">
                    <asp:Label ID="Label13" runat="server" Text="Họ tên"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txthoten" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style20" style="background:#DEE8F5;">
                    <asp:Label ID="Label6" runat="server" Text="Ngày sinh"></asp:Label>
                </td>
                <td>
                    <dxe:ASPxDateEdit ID="txtDate" runat="server" Height="10px" Width="200px">
                    </dxe:ASPxDateEdit>
                </td>
            </tr>
            <tr>
                <td class="style20" style="background:#DEE8F5;">
                    <asp:Label ID="Label12" runat="server" Text="Giới tính"></asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="ckbgioitinh" runat="server" Text="Nam" />
                </td>
            </tr>
            <tr>
                <td class="style20" style="background:#DEE8F5;">
                    <asp:Label ID="Label4" runat="server" Text="Lớp"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddllop" runat="server" Width="100px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style20" style="background:#DEE8F5;">
                    <asp:Label ID="Label3" runat="server" Text="Chức vụ"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtchucvu" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style20" style="background:#DEE8F5;">
                    <asp:Label ID="Label2" runat="server" Text="Học kỳ"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlhocky" runat="server" Width="100px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style20" style="background:#DEE8F5;">
                    <asp:Label ID="Label5" runat="server" Text="Địa chỉ"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtdiachi" runat="server" Height="44px" TextMode="MultiLine" 
                        Width="155px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style20" style="background:#DEE8F5;">
                    <asp:Label ID="Label11" runat="server" Text="Số điện thoại"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtsodienthoai" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style20" style="background:#DEE8F5;">
                    <asp:Label ID="Label10" runat="server" Text="Hõ tên cha"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txthotencha" runat="server" Style="margin-bottom: 0px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style20" style="background:#DEE8F5;">
                    <asp:Label ID="Label9" runat="server" Text="Nghề nghiệp cha"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtnghenghiepcha" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style20" style="background:#DEE8F5;">
                    <asp:Label ID="Label8" runat="server" Text="Họ tên mẹ"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txthotenme" runat="server"></asp:TextBox>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style20" style="background:#DEE8F5;">
                    <asp:Label ID="Label7" runat="server" Text="Nghề nghiệp mẹ"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtnghenghiepme" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        </div>
        <div class="table" align="center">
            <asp:Panel ID="Panel2" runat="server" GroupingText="" 
                        Height="150px" Width="215px">
                        <asp:Panel ID="Panel3" runat="server" Height="15px" Width="212px">
                            <div class="title"><h6>Dành cho học sinh chuyển cấp</h6></div>
                            <table class="style10">
                                <tr>
                                    <td class="style20" style="background:#DEE8F5;">
                                        <asp:Label ID="Label15" runat="server" Text="Điểm TB"></asp:Label>
                                    </td>
                                    <td style="width: 160px">
                                        <asp:TextBox ID="TextBox1" runat="server" Width="123px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style20" style="background:#DEE8F5;">
                                        <asp:Label ID="Label16" runat="server" Text="Hạnh kiểm"></asp:Label>
                                    </td>
                                    <td style="width: 160px">
                                        <asp:TextBox ID="TextBox2" runat="server" Width="124px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </asp:Panel>
        </div>
        <br />
        <br />
        <div>
            <asp:Button ID="btnluuthongtin" runat="server" OnClick="btnluuthongtin_Click" 
                Text="Lưu" />
            <asp:Button ID="btnhuy" runat="server" OnClick="btnhuy_Click" Text="Hủy" />
        </div>
    </asp:Panel>
    

    <script language="javascript" type="text/javascript">
// <!CDATA[

function Submit1_onclick() {

}

// ]]>
    </script>

</asp:Content>
