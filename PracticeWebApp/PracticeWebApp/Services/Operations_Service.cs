// Service are used to Clean Controller,Reusable Bussiness logic , Easy Testing , Better Project Architecture

namespace PracticeWebApp.Services
{
    public class Operations_Service : IOperations //inheriting (implementing) the IAddition interface, so this class must define every method declared in it.
    {
        public int AddTwoNumbers(int a , int b) //Takes two numbers and returns their sum back to the controller.
        {
            return a + b;
        }
        public int SubstractTwoNumber(int a, int b) //Takes two numbers and returns the difference (a minus b).
        {
            return a - b;
        }
        public int MultiplyTwoNumber(int a, int b) //Takes two numbers and returns the multiple.
        {
            return a * b;
        }
        public double DevideTwoNumber(int a, int b) //Takes two numbers and returns the division.
        {
            return (double)a / b; //Type casting
        }
    }
}

/*
 
 Flow:
   View -> Controller -> Service -> Controller -> View


 There Are 3 Diffrent Types Of Service:
   1) Transient Service: A new object is created EVERY time it is asked for (even twice in the same request). Best for lightweight, stateless services.
   2) Scoped Service:    ONE object is created per HTTP request and reused everywhere within that same request, then thrown away. Good default for most services.
   3) Singleton Service: ONLY ONE object is created for the whole application and shared by every user/request until the app stops. Use for shared/global data.

 In short: Transient = new every time, Scoped = one per request, Singleton = one for the entire app.
*/


