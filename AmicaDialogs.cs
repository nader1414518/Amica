using Syn.Bot.Oscova;
using Syn.Bot.Oscova.Attributes;
using System;
using UnityEngine;
using ArabicSupport;


namespace BotDialogs
{
    public class AmicaDialogs : Dialog
    {
        [Expression("InitializeBot")]
        public void InitializeBot(Context context, Result result)
        {
            if (Globals.currentUser.isFirstTime != "no")
            {
                result.SendResponse("هاااااي انا صديقتك اميكا سعيده ان بكلمك دلوقتي و اتمنى اننا نكون اصدقاء قريبين ❤️ ⁩");
                Globals.currentUser.isFirstTime = "no";
                context.Add("Greetings", 2);
            }
        }
        [Expression("Hey Bot")]
        public void HeyBot(Context context, Result result)
        {
            result.SendResponse("انت عامل ايه النهارده كدا");
            context.Add("Greetings", 2);
        }
        [Fallback]
        public void DefaultFallback(Context context, Result result)
        {
            result.SendResponse("معلش يا صاحبي انا لسه بتعلم ...");
            result.SendResponse("تسمع حاجه؟ ");
            context.Add("SongSuggestions", 2);
        }
        #region UnexpectedInputHandling
        [Context("UnexpectedInput")]
        public void UnexpectedInputHandler(Context context, Result result)
        {
            
        }
        #endregion

        //private static readonly string kweesExpression = ArabicFixer.Fix("كويس");
        [Expression("عظمه")]
        [Expression("فل")]
        [Expression("الحمد لله")]
        [Expression("حلو")]
        [Expression("جميل")]
        [Expression("تمام")]
        [Expression("كويس")]
        [Expression("Fine")]
        [Expression("Good")]
        [Expression("Amazing")]
        [Expression("Awesome")]
        [Context("Greetings")]
        public void KweesGreetingResponse(Context context, Result result)
        {
            result.SendResponse("يارب دايما ... ايه اخبار المذاكره؟ ");
            context.Add("Kalam3nElmozakra", 2);
        }
        #region UserChilling
        [Expression("كويسه")]
        [Expression("ماشيه")]
        [Expression("حلوه")]
        [Expression("تمام")]
        [Context("Kalam3nElmozakra")]
        public void WhatIsGoingOnWithStudyingResponse(Context context, Result result)
        {
            result.SendResponse("عاش يا صاحبي ");
            result.SendResponse("تسمع اغاني؟ ");
            context.Add("SongSuggestions", 2);
        }
        #endregion

        #region UserMshTmam
        [Expression("نص نص")]
        [Expression("مش حلو")]
        [Expression("مش اد كدا")]
        [Expression("مش تمام")]
        [Expression("Not so good")]
        [Expression("Not well")]
        [Context("Greetings")]
        public void MshTmamGreetingResponse(Context context, Result result)
        {
            result.SendResponse("ليه كدا بس يا صاحبي ");
            context.Add("UserMshTmam", 2);
        }

        [Expression("مخنوق")]
        [Expression("مفيش")]
        [Expression("يعني")]
        [Expression("مضغوط")]
        [Expression("Just fed up")]
        [Expression("Nothing")]
        [Context("UserMshTmam")]
        public void MotivateUserResponse(Context context, Result result)
        {
            context.Add("UserMshTmam", 2);
            result.SendResponse("ايه رأيك نفرفش شويه؟ ");
        }
        [Expression("اشطا")]
        [Expression("ماشي")]
        [Expression("تمام")]
        [Context("UserMshTmam")]
        public void SuggestSongResponse(Context context, Result result)
        {
            result.SendResponse("تسمع اغاني؟ ");
            context.Add("SongSuggestions", 2);
        }
        #endregion
        [Expression("مش حلوه")]
        [Expression("لا")]
        [Expression("مش اد كدا")]
        [Expression("وحشه")]
        [Expression("فاكس")]
        [Expression("تانيه")]
        [Expression("مبحبهاش")]
        [Expression("مش عايز")]
        [Context("SongSuggestions")]
        public void RejectSongResponse(Context context, Result result)
        {
            result.SendResponse("طب احكيلي شويه عن اللي مضايقك");
            context.Add("ListenToProblems", 1);
        }

        [Expression(" ")]
        [Context("ListenToProblems")]
        public void ListenToUserProblems(Context context, Result result)
        {
            result.SendResponse("كله هيبقا تمام يا صاحبي متقلقش المهم خليك متفائل بس متفقدش الامل وانا هنا دايما لو عايز تتكلم");
        }

        [Expression("ماشي")]
        [Expression("عظمه")]
        [Expression("فل")]
        [Expression("اشطا")]
        [Expression("تمام")]
        [Expression("حلو")]
        [Expression("جميل")]
        [Expression("كويس")]
        [Context("SongSuggestions")]
        public void ViewSongsResponse(Context context, Result result)
        {
            result.SendResponse("ما تفتح يوتيوب وخلاص يعم ");
            result.SendResponse("بهزر معاك 😂");
            result.SendResponse("Sia - Never Give Up\n ايه رأيك نسمع دي؟");
            context.Add("SongSuggestionResponse", 2);
        }
        [Expression("مش حلوه")]
        [Expression("لا")]
        [Expression("مش اد كدا")]
        [Expression("وحشه")]
        [Expression("فاكس")]
        [Expression("تانيه")]
        [Expression("مبحبهاش")]
        [Expression("مش عايز")]
        [Context("SongSuggestionResponse")]
        public void BadSongResponse(Context context, Result result)
        {
            result.SendResponse("خلاص نشوف فيلم حلو كدا؟ ");
            context.Add("MovieSuggestions", 1);
        }

        [Expression("ماشي")]
        [Expression("عظمه")]
        [Expression("فل")]
        [Expression("اشطا")]
        [Expression("تمام")]
        [Expression("حلو")]
        [Expression("جميل")]
        [Expression("كويس")]
        [Expression("حلوه")]
        [Expression("كويسه")]
        [Expression("بحبها")]
        [Expression("يلا")]
        [Expression("يله")]
        [Context("MovieSuggestions")]
        public void MovieSuggestionResponse(Context context, Result result)
        {
            result.SendResponse("ماشي");
        }


        [Expression("ماشي")]
        [Expression("عظمه")]
        [Expression("فل")]
        [Expression("اشطا")]
        [Expression("تمام")]
        [Expression("حلو")]
        [Expression("جميل")]
        [Expression("كويس")]
        [Expression("حلوه")]
        [Expression("كويسه")]
        [Expression("بحبها")]
        [Expression("يلا")]
        [Expression("يله")]
        [Context("SongSuggestionResponse")]
        public void GoodSongResponse(Context context, Result result)
        {
            result.SendResponse("https://www.youtube.com/watch?v=-oTq-FfOsBk");
            result.SendResponse("ريلاكس كدا يا صاحبي");
            context.Add("RelaxationZone", 1);
        }
        [Expression("ماشي")]
        [Expression("عظمه")]
        [Expression("فل")]
        [Expression("اشطا")]
        [Expression("تمام")]
        [Expression("حلو")]
        [Expression("جميل")]
        [Expression("كويس")]
        [Expression("حلوه")]
        [Expression("كويسه")]
        [Expression("بحبها")]
        [Expression("يلا")]
        [Expression("يله")]
        [Expression("هسمعها")]
        [Context("RelaxationZone")]
        public void RelaxationZone(Context context, Result result)
        {
            result.SendResponse("بالتوفيق يا صحبي");
        }
    }

    public class BoredUser : Dialog
    {
        [Expression("I'm bored")]
        public void SuggestSomethingFun(Context context, Result result)
        {
            int ch = UnityEngine.Random.Range(1, 4);
            context.Add("UserMshTmam", 2);
            result.SendResponse("Do you like reading? I've some good reads for you.");
        }
    }
}
