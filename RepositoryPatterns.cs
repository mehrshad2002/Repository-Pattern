
//Repository Pattern with ADO.Net
//mehrshad2002

class Users{
	public int ID ;
	public string Name ;
	public string Password;
	
	public Users(){}
}

public interface IUsers{
	
	Ilist<Users> GetUsers(); //get all users
	Users GetUsersByID( int ID ); // Get one users by ID
	bool Insert(Users); // add One users 
	bool Delete(int ID ); // delete one users by ID
	bool Update(Users); // Update one users by users and obj 
}

public Class MainApp : IUsers{
	private string cs = "<DataBase File Path>"; // connection String 
	
		public Ilist<Users> GetUsers(){
			List<Users> users = new List<Users>();
			using(SqlConnection con = new SqlConnection(cs)){
				string QueryGetUsers = "select * from Users";
				SqlCommand cdm = new SqlCommand(QueryGetUsers,cs);
				cmd.CommandType = CommandType.StoredProcedure;    
				con.Open();
				SqlDataReader rdr  = cmd.ExecuteReader();
				
				Users user = new Users();
				while(rdr.Read()){
					// rdr --> all data & obj reader
					user.Name = rdr["Name"];
					user.ID = Convert.ToInt32(rdr["ID"]);
					user.Password = rdr["Password"];
					
					users.Add(user);
				}
				return users; // in IO pannel we can shw all Data 
			}
		
		public Users GetUsersByID(int ID){
			
			using(SqlConnection con = new SqlConnection(cs)){
				string QueryGetUsersByID = $"select * Users where ID = {ID}";
				SqlCommand cmd = new SqlCommand(QueryGetUsersByID , con );
				con.open();
				SqlDataReader rdr = cmd.ExecuteReader();
				
				Users user = new Users();
				while(rdr.Read()){
					user.Name = rdr["Name"];
					user.Password = rdr["Password"];
					user.ID = Convert.ToInt32(rdr["ID"]);
				}
				
				return user ;
			}
		} 
		
		public bool Insert(Users user ){
			using(SqlConnection con = new SqlConnection(cs)){
				string QueryInsertUser = "insert into Users Values({user.ID} , '{user.Name}' , '{user.Password}')";
				SqlCommand cmd = new SqlCommand(QueryGetUsers , con );
				con.Open();
				try{
					int Result = cmd.ExecuteNoneQuery();
					if(Result != 0 ){
						return true ;
					}else{
						return false;
					}
				}			
			}
		}
		
		public bool Delete(int ID ){
			using(SqlConnection con = new SqlConnection(cs)){
				string QueryDelete = $"delete from Users where ID = {ID}";
				SqlCommand cmd = new SqlCommand(QueryDelete , cs );
				con.Open();
				try{
					int Result = cmd.ExecuteNoneQuery();
					if(Result != 0 ){
						return true ;
					}else{
						return false;
					}
				}
			}
		}
		
		public bool Update(Users user ){
			using(SqlConnection con = new SqlConnection()){
				string QueryUpdate = "Update Users Set ID = {user.ID} , Name = '{user.Name}' , Password = {user.Password}";
				SqlCommand cmd  = new SqlCommand(QueryUpdate , con );
				con.Open();
				try{
					int Result = cmd.ExecuteNoneQuery();
					if(Result != 0 ){
						return true ;
					}else{
						return false;
					}
				}
			}
		}
	}
}