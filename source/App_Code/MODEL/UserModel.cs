
/// <summary>
/// 存储用户信息
/// </summary>
public class UserModel
{
    /// <summary>
    /// 初始化用户模型层
    /// </summary>
	public UserModel()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    public string uid { get; set; }
    public string uname { get; set; }
    public string upwd { get; set; }
    public string email { get; set; }
    public string utype { get; set; }
    public string status { get; set; }
    public string uinfo { get; set; }
    public string sex { get; set; }
    public string avatorurl { get; set; }

}