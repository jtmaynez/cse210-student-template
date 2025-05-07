class Applicant {
    public string _firstName;
    public string _lastName;

    public string _phoneNumber;

    public string _emailAddress;
     
     public int _orderOfApplication;
     public int _rank;
    //  public  _resume;
     public void Display()
     {
      Console.WriteLine($"Applicant: {_firstName} {_lastName} Number: {_phoneNumber} Email: {_emailAddress} Ranked: {_rank}");  
     }

}
