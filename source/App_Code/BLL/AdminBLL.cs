using System.Data.SqlClient;
using System.Text;

/// <summary>
/// 管理层
/// </summary>
public class AdminBLL
{
	public AdminBLL()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    Data mydata = new Data();

    public SqlDataReader GetRoomList()
    {
        SqlDataReader dr=mydata.ReadDB("select rid from croom");
        return dr;
    }

    public bool AddRoom(int max)
    {
        string cmd = string.Format("insert into croom values('admin',0,{0},'')", max);
        if (mydata.ExcCmd(cmd) > 0)
            return true;
        else
            return false;
    }

    public bool DelRoom(int rid)
    {
        string cmd = string.Format("delete from croom where rid={0}", rid);
        if (mydata.ExcCmd(cmd) > 0)
            return true;
        else
            return false;
    }

    public bool UpdateAnnounce(int rid, string anc)
    {
        byte[] data = Encoding.Default.GetBytes(anc);
        string m = Encoding.Default.GetString(data);
        string cmd = string.Format("update croom set r_announce=N'{0}' where rid={1}",m,rid);
        if (mydata.ExcCmd(cmd) > 0)
            return true;
        else
            return false;
    }

    public bool BanUser(string uname)
    {
        string cmd = string.Format("update myuser set status=-1 where uname=N'" + uname + "'");
        if (mydata.ExcCmd(cmd)>0)
            return true;
        else
            return false;
    }

    public bool ActUser(string uname)
    {
        string cmd = string.Format("update myuser set status=0 where uname=N'" + uname + "'");
        if (mydata.ExcCmd(cmd) > 0)
            return true;
        else
            return false;
    }
}