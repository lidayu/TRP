using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text;
using System.Runtime.Serialization;
using System.Json;



namespace JsonLength
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Encoding aEn =Encoding.GetEncoding("GB18030");
            string xml1 = @"<申请书>	<EqukCommon>	<类型>个人结算账户申请书</类型>	<省市代码>99</省市代码>	<电子模板版本>20130507</电子模板版本></EqukCommon>	<申请人>本人办理</申请人>	<代理人信息>											<证件是否永久有效>否</证件是否永久有效>				</代理人信息>	<客户信息>	<姓名>李大宇</姓名>	<证件种类代码>110001</证件种类代码>	<证件类型>居民身份证</证件类型>	<证件号码>410621198704244554</证件号码>	<性别>女</性别>	<国家数字码>156</国家数字码>	<国籍>中国</国籍>	<民族代码>01</民族代码>	<民族>汉族</民族>	<证件是否永久有效>否</证件是否永久有效>	<证件有效起始日期>20011010</证件有效起始日期>	<证件有效截止日期>20191010</证件有效截止日期>		<签发机关>天津市</签发机关>		<移动电话>13666666666</移动电话>			<首选1>是</首选1>	<联系地址1>beij</联系地址1>	<邮编1>100068</邮编1>				<首选2>否</首选2>	<联系地址2>nanj</联系地址2>	<邮编2>100073</邮编2>			</客户信息>	<开户信息>	<开户类型>普通卡</开户类型>							</开户信息>	<申请业务功能>	<电子银行业务>	<网上银行>					</网上银行>	<电话银行>						</电话银行>	<掌上银行>					</掌上银行>	<消息服务>				</消息服务>	<现金类自助设备>			</现金类自助设备>	<服务费账户></服务费账户></电子银行业务>	<投资类业务>								</投资类业务>	<账务处理>	<开户金额>1000.00</开户金额>	<币种>人民币</币种>		<其他币种代码>12</其他币种代码>	<钞汇标志>现钞</钞汇标志>	<现转标志>现金</现转标志>			</账务处理></申请业务功能></申请书>";
            string newXml = xml1.Replace(" ", "");
            int kk = aEn.GetBytes(newXml).Length;
            JsonObject jObject = new JsonObject();
           
            string json1 = "{  \"申请书\": {    \"EqukCommon\": {      \"类型\": \"个人结算账户申请书\",      \"省市代码\": \"99\",      \"电子模板版本\": \"20130507\"    },    \"申请人\": \"本人办理\",    \"代理人信息\": { \"证件是否永久有效\": \"否\" },    \"客户信息\": {      \"姓名\": \"李大宇\",      \"证件种类代码\": \"110001\",      \"证件类型\": \"居民身份证\",      \"证件号码\": \"410621198704244554\",      \"性别\": \"女\",      \"国家数字码\": \"156\",      \"国籍\": \"中国\",      \"民族代码\": \"01\",      \"民族\": \"汉族\",      \"证件是否永久有效\": \"否\",      \"证件有效起始日期\": \"20011010\",      \"证件有效截止日期\": \"20191010\",      \"签发机关\": \"天津市\",      \"移动电话\": \"13666666666\",      \"首选1\": \"是\",      \"联系地址1\": \"beij\",      \"邮编1\": \"100068\",      \"首选2\": \"否\",      \"联系地址2\": \"nanj\",      \"邮编2\": \"100073\"    },    \"开户信息\": { \"开户类型\": \"普通卡\" },    \"申请业务功能\": {      \"电子银行业务\": {        \"网上银行\": \"					\",        \"电话银行\": \"						\",        \"掌上银行\": \"					\",        \"消息服务\": \"				\",        \"现金类自助设备\": \"			\"      },      \"投资类业务\": \"								\",      \"账务处理\": {        \"开户金额\": \"1000.00\",        \"币种\": \"人民币\",        \"其他币种代码\": \"12\",        \"钞汇标志\": \"现钞\",        \"现转标志\": \"现金\"      }    }  }}";
            string newJson=json1.Replace(" ", "");

            int k2 = aEn.GetBytes(newJson).Length;
            label1.Content = "XML Length:"+kk.ToString();
            label2.Content = "Json Length:" + k2.ToString();
        }
    }
}
