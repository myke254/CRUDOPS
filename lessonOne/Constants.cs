namespace lessonOne
{
    public class MyConstants
    {
       
       public string initialGreeting = "Hello There!, What's your name";
      public string invalidName= "Hello There!, the name you provided is invalid";
      public string AskForYOB(string name){
        return  $"Hi {name},\nWhat year were you born?";
      }
      public string invalidYear (string name){
        return $"The Year of Birth is invalid {name} give us a valid Year of birth please😢";
      }
      public string ageMessage(int age){
        return age < 120 ? $"{age} years old" : "dead";
      }
      public string finalMessage(string name,string myAge){
        return $"Great work {name}, Let me Guess,\nYou must be {myAge} right?";
      }
     
    }
}