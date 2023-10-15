using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using WeatherServiceRef;

public partial class UserControl_Weather : System.Web.UI.UserControl
{
  WeatherWebService weather = new WeatherWebService();
  protected void Page_Load(object sender, EventArgs e)
  {
    try
    {
      //获得本天气预报服务支持的洲、国内外省份和城市信息
      DataSet ds = weather.getSupportDataSet();
      if (!Page.IsPostBack)
      {
        DataTable dt = ds.Tables[0];
        ddlProvince.DataSource = dt;
        //将支持的洲、国内省份（直辖市、特别行政区）代码绑定到DataValueField
        ddlProvince.DataValueField = "ID";
        //将支持的洲、国内省份（直辖市、特别行政区）名称绑定到DataTextField
        ddlProvince.DataTextField = "Zone";//显示省洲名称
        ddlProvince.DataBind();
        ddlCity.SelectedIndex = 1;
        //调用自定义方法CityDataBind()，"1"表示直辖市
        CityDataBind("1");
        //调用自定义方法GetWeatherByCode()，"54511"表示北京
        GetWeatherByCode("54511");
      }
    }
    catch (Exception)
    {
      lblError.Text = "网络连接异常！";
    }
  }

  /// <summary>
  /// 将指定ZoneID值对应的城市名和城市代码填充到城市下拉列表中
  /// </summary>
  /// <param name="zoneID">指定的区域编号</param>
  protected void CityDataBind(string zoneID)
  {
    DataView dv = new DataView(weather.getSupportDataSet().Tables[1]);
    //筛选的条件是ZoneID的值等于zoneID的值
    dv.RowFilter = "[ZoneID] = " + zoneID;
    ddlCity.DataSource = dv;
    //选择数据视图dv中的城市名数据列Area绑定到DataTextField
    ddlCity.DataTextField = "Area";
    ddlCity.DataValueField = "AreaCode";
    ddlCity.DataBind();
    ddlCity.Items.Insert(0, new ListItem("选择城市", "0"));
    ddlCity.SelectedIndex = 0;
  }

  /// <summary>
  /// 根据指定的城市代码查询未来三天内天气情况和现在的天气实况
  /// </summary>
  /// <param name="cityCode">指定的城市代码</param>
  protected void GetWeatherByCode(string cityCode)
  {
    //wa数组存储天气状况信息，共有23个元素     
    String[] wa = weather.getWeatherbyCityName(cityCode.Trim());
    //选择的省份、城市
    lblCity.Text = wa[0] + " / " + wa[1];
    //现在的天气实况
    lblNow.Text = wa[10];
    //当天的气温，概况，风向和风力
    lblToday.Text = wa[6] + "&nbsp;&nbsp;&nbsp;" + wa[5] + "&nbsp;&nbsp;&nbsp;" + wa[7];
    //明天的气温，概况，风向和风力
    lblTomorrow.Text = wa[13] + "&nbsp;&nbsp;&nbsp;" + wa[12] + "&nbsp;&nbsp;&nbsp;" + wa[14];
    //后天的气温，概况，风向和风力
    lblAfterTmr.Text = wa[18] + "&nbsp;&nbsp;&nbsp;" + wa[17] + "&nbsp;&nbsp;&nbsp;" + wa[19];
    //显示天气趋势开始图片名称(简称图标一)和天气趋势结束图片名称(简称图标二)
    imgWeathertrendsTdS.ImageUrl = "~/Images/weather/" + wa[8];  //今天的图标一
    imgWeathertrendsTdE.ImageUrl = "~/Images/weather/" + wa[9];  //今天的图标二
    imgWeathertrendsTmS.ImageUrl = "~/Images/weather/" + wa[15];  //明天的图标一
    imgWeathertrendsTmE.ImageUrl = "~/Images/weather/" + wa[16];  //明天的图标二
    imgWeathertrendsAfS.ImageUrl = "~/Images/weather/" + wa[20];  //后天的图标一
    imgWeathertrendsAfE.ImageUrl = "~/Images/weather/" + wa[21];  //后天的图标二
  }

  protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
  {
    //调用自定义方法CityDataBind()
    CityDataBind(ddlProvince.SelectedItem.Value.Trim());
  }

  protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
  {
    if (ddlCity.Items[0].Value == "0")
    {
      ddlCity.Items.RemoveAt(0);
    }
    //调用自定义方法GetWeatherByCode()
    GetWeatherByCode(ddlCity.SelectedItem.Value.Trim());
  }
}