using System;
using System.Collections.Generic;
using System.Threading;
using Mountain.classes.tcp;
using Mountain.classes.functions;


namespace Mountain.classes.dataobjects {

    public class StringResources {
        public List<string> Responses;


        public StringResources() {
            PopulateLists();
        }

        private void PopulateLists() {
            string[] responses = {
                "I really don't know what to do with %%.",
                "You'd think I'd know what to do with %% by now, wouldn't you.",
                "If I knew what to do with %% I'd maybe still not do it for you.. *eyes you suspiciously*.",
                "And with just who do I have to watch you %% with?",
                "I've known you for what.. at least a little while now, and you are already asking me to %% for you?",
                "I'm not even gonna ask what %% is.",
                "Would you actually %% if you were me? I'd not do it if I were you, which, thankfully, I'm not.",
                "I've tried %% before and somehow you're still here sorta. Where's my bigger fly swatter gone..",
                "Sure, do this %% you say, so just how would you expect me to actually do that?",
                "Yeah, right, %%, I wont even ask why you thought that up.",
                "Yeah, right, %%, I'm sure I heard that one coming.",
                "I've lost my %% wand again, sorry.",
                "I'm sure there's a dictionary with %% in it somewhere. Look it up for me will yeah?",
                "Really? You remember what happened the last time you wanted to %%?",
                "Alright.. %%.. sure.. let me find my magic what's-it-wand first though.",
                "I'm just not gonna do %% for you. Nope, no way.. well.. OK, maybe after the moon's turned green a bit more..",
                "%% - Now that's just plain silly. Stop messing with me!..go away even!!..*sigh*.. OK, just let me put something on first.",
                "%% - Maybe, if you started treating me like the god I am, I'll find a way to actually do this weird request you ask.",
                "%% - Humph.. I see typing isn't one of your strong suits.",
                "%% - Drinking again are we?",
                "%% - Give me a break. And put some cloths on before typing anything else!",
                "%%.. OK, now I'm giggling.",
                "%% - *Blush*.",
                "%% - The last time I tried that for you, my thumbs shrunk an inch.",
                "%% - You really, really want me to slap you, don't you.",
                "%% - OK, now my palm is itchy.",
                "%% - How many times do I have to tell you to stop doing that.",
                "%% - Sure, and for a twenty I'll throw in a midget pink mushroom cloud.",
                "%%.. well it isn't my sanity thats on the line here, is it.",
                "%% - I'm not sure that's such a good idea, *shiver*.",
                "%% - You mean, right this very minute?",
                "%% - And just what is it we're smoking today?",
                "%% - You did say you went to school now didn't you? School of lazy typists?"};
            Responses = new List<string>(responses);
        }

        public string DontKnowHow(string value, Connection player) {
            string response = string.Empty;
            if (player.StringStack.Count == 0) {
                Responses.Shuffle();
                foreach (string item in Responses) {
                    player.StringStack.Push(item);
                }
            }
            response = player.StringStack.Pop();
            string command = " \"".Color(Ansi.white) + value + "\"".Color(Ansi.white, Ansi.yellow);
            response = response.Replace("%%", command).Color(Ansi.yellow).NewLine();
            return response;
        }
    }



    public static class ThreadSafeRandom {
        [ThreadStatic]
        private static Random Local;

        public static Random ThisThreadsRandom {
            get { return Local ?? (Local = new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId))); }
        }
    }

    static class ListExtensions {
        public static void Shuffle<T>(this IList<T> list) {
            int n = list.Count;
            while (n > 1) {
                n--;
                int k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
