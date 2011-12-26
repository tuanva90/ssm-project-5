<%@ Page Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true" CodeFile="QuanLyDiemHK.aspx.cs" Inherits="Admin_QuanLyDiemHK" Title="Untitled Page" %>

<script runat="server">

   
</script>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
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
            margin-top: 0px;
        }
        </style>
    <p style="text-align: center">
        &nbsp;</p>
             <p class="style18" style="text-align: center; height: 4px;" 
        __designer:mapid="8e">
                 Điểm từng lớp theo môn học</p>
    <p class="style18" style="text-align: center; height: 4px;" 
        __designer:mapid="8e">
                 &nbsp;</p>
    <p class="style18" style="text-align: center; height: 4px;" 
        __designer:mapid="8e">
                 &nbsp;</p>
            <p>
                                <asp:Label ID="Label2" runat="server" Text="Năm học :"></asp:Label>
                                <asp:DropDownList ID="ddnamhoc" runat="server" Height="25px" 
                                    AutoPostBack="True" DataTextField="Năm học" 
                                    DataValueField="Mã năm" 
                                    Width="115px" onselectedindexchanged="ddnamhoc_SelectedIndexChanged">
                                </asp:DropDownList>
    &nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Text="Học kỳ :"></asp:Label>
&nbsp;<asp:DropDownList ID="ddlhk" runat="server" DataTextField="Học kỳ" 
                    DataValueField="Mã HK" AutoPostBack="True" 
                                    onselectedindexchanged="ddlhk_SelectedIndexChanged" style="height: 22px">
                </asp:DropDownList>
&nbsp;</p>
    <p>
                <asp:Label ID="Label4" runat="server" Text=" "></asp:Label>
                <asp:Label ID="Label5" runat="server" Text="Lớp : "></asp:Label>
                <asp:DropDownList ID="ddllop" runat="server" AutoPostBack="True" 
                    DataTextField="Tên lớp" DataValueField="Mã lớp" 
                    onselectedindexchanged="ddllop_SelectedIndexChanged">
                </asp:DropDownList>
&nbsp;&nbsp;&nbsp;<asp:Label ID="Label6" runat="server" Text="Môn học : "></asp:Label>
                &nbsp;
                <asp:DropDownList ID="ddlmonhoc" runat="server" AutoPostBack="True" 
                    DataTextField="Tên môn" DataValueField="Mã môn" 
                    onselectedindexchanged="ddlmonhoc_SelectedIndexChanged">
                </asp:DropDownList>
    </p>
    <p>
                <asp:Label ID="lblinfor" runat="server" ForeColor="Blue" Text="Label"></asp:Label>
    </p>
    <div align = center>
                    <asp:GridView ID="gvhocsinh" runat="server" AllowPaging="True" 
                        AutoGenerateColumns="False" CellPadding="4" CssClass="style13" 
                        ForeColor="#333333" GridLines="Horizontal" ShowFooter="True" 
                        Width="700px" HorizontalAlign="Center" 
                        onselectedindexchanged="gvhocsinh_SelectedIndexChanged">
                        <RowStyle BackColor="#E3EAEB" />
                        <Columns>
                            <asp:TemplateField HeaderText="Mã học sinh" InsertVisible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblmahs" runat="server" CssClass="style9" 
                                        Text='<%# Eval("Mã HS") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
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
                                </FooterTemplate>
                                <ControlStyle CssClass="style9" Width="200px" />
                                <FooterStyle CssClass="style9" />
                                <HeaderStyle CssClass="style9" Width="300px" />
                                <ItemStyle CssClass="style9" Width="200px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Điểm 15p">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtdiem15p" runat="server" Text='<%# Eval("Điểm 15p") %>'></asp:TextBox>
                                </ItemTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle Width="100px" CssClass="style9" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Điểm miệng">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtdiemmieng" runat="server" Text='<%# Eval("Điểm miệng") %>'></asp:TextBox>
                                </ItemTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle CssClass="style9" Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Điểm 1 tiết">
                                <EditItemTemplate>
                                    <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:LinkButton ID="btnluudiem" runat="server" onclick="btnluudiem_Click">Lưu 
                                    điểm</asp:LinkButton>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="txtdiem1tiet" runat="server" Text='<%# Eval("Điểm 1t") %>'></asp:TextBox>
                                </ItemTemplate>
                                <ControlStyle CssClass="style9" Width="100px" />
                                <ItemStyle Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Điểm TBKT">
                                <ItemTemplate>
                                    <asp:Label ID="lbldiemtbkt" runat="server" Text='<%# Eval("Điểm TBMKT") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:LinkButton ID="lbtntinhdiemtbkt" runat="server" 
                                        onclick="lbtntinhdiemtbkt_Click">Tính điểm TBKT</asp:LinkButton>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Điểm HK">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtdiemhk" runat="server" Text='<%# Eval("Điểm HK") %>' 
                                        Width="40px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rq1" runat="server" 
                                        ControlToValidate="txtdiemhk" ErrorMessage="*" ValidationGroup="va1" 
                                        CssClass="style10" Display="Dynamic"></asp:RequiredFieldValidator>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Điểm TB">
                                <ItemTemplate>
                                    <asp:Label ID="lbldiemtb" runat="server" Text='<%# Eval("Điểm TB") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:LinkButton ID="lbldiemtb" runat="server" onclick="lbldiemtb_Click" 
                                        ValidationGroup="va1">Tính điểm TB</asp:LinkButton>
                                </FooterTemplate>
                                <ControlStyle CssClass="style9" Width="100px" />
                                <ItemStyle CssClass="style9" Width="100px" />
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
    <p>
                                &nbsp;</p>
                 </br>
                </br>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
</asp:Content>









