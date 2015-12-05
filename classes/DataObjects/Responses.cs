using System;
using System.Linq;
using System.Collections.Generic;
using Mountain.classes.tcp;
using Mountain.classes.functions;


namespace Mountain.classes.dataobjects {

    [Serializable] public class StringResponses {
        public List<string> Responses;

        public StringResponses() {
            PopulateLists();
        }

        private void PopulateLists() {
            string[] responses = {
                "I really don't know what to do with %%.",
                "No, my powers can only be used for good, so just stop asking me to %% for you.",
                "You'd think I'd know why you'd want me to do %% for you by now wouldn't you.",
                "Yes, I'm an agent of Satan too, but my duties are a bit more ceremonial than what your %% duties seem to entail.",
                "I'm starting to visualize the %% that's now dripping over your keyboard. But try to keep it at your end, huh?",
                "I don't know what your finger problems are, but I'll bet it's as hard to pronounce as %% is to do.",
                "If I knew what to do with %% I'd still maybe not do it for you.. *eyes you suspiciously*.",
                "I've known you for what.. at least since you've logged on, and you are already asking me to %%??",
                "I'm definitely not gonna ask what %% is.",
                "Would you actually %% if you were me? I'd definitely not do it if I were you, which, most thankfully, I'm not.",
                "I've tried %% before and somehow you're still here. Where's my bigger fly swatter..",
                "Sure, do this %% now you say, and just how would you expect me to actually do it?",
                "Yeah, right, %%, I can't even begin to think why you'd ever mention it out loud.",
                "*Blink* I have but two brain cells left since you've come on, (one trying to push the other around in a wheelchair) so maybe you could please explain %%?",
                "Yeah, %%, like I didn't see that one coming after I heard you logged in.",
                "I seem to have lost my %% wand once again, so sorry.. *roll*.",
                "I'm sure there's a dictionary with %% in it somewhere.",
                "You don't remember what happened the last time you wanted to %%?",
                "Alright.. %%.. sure.. let me find my magic what's-its-wand first though.",
                "I'm just not gonna do %% for you. Nope, no way, not ever again.",
                "%% should really come with a warning label.",
                "%% - Now that's just plain silly. Stop messing with me!..go away even!!..*sigh*...let me put something on first then.",
                "%% - Maybe, if you started treating me like the god I am, I'd find a way to actually do this really weird request.",
                "%% - Humph.. I see typing isn't one of our strong suits.",
                "%% - Drinking again are we?",
                "%% - Give me a break. And put some cloths on before you say anything! Sheesh.",
                "%%.. OK, now I'm having a wee giggle fit.",
                "%% - *Blush*.",
                "%% - last time I tried that my ears curled up.",
                "%% - You really, really want me to slap you around a bit now don't you.",
                "%% - OK, now my hairy palm is itchy.",
                "%% - How many times do I have to tell you to stop trying that.",
                "%% - Sure, and for a nickel I'll throw in a pink four leaf clover.",
                "%% - .. well it isn't my sanity thats on the line here now is it.",
                "%% - umm..some advice.. on the keyboard of life, always keep one finger on the escape key and both elbows off the board.",
                "%% - umm..my five levels of reality checks all bounced.",
                "%% - I'm not sure that's such a good idea, *eyes you suspiciously*.",
                "%% - You're sounding rather reasonable.. Time to up my meds.",
                "%% - *Blink*.. someday we'll look back on that, laugh nervously and change the subject.",
                "%% - You actually mean right this very moment?",
                "%% - I know you only drink alcohol to make me seem more interesting.. so just how's that working for you at the moment?",
                "%% - And just what is it we're smoking today?",
                "%% - I know you're not slurring your words, you're just talking cursive again.",
                "%% - You did say you went to school right? School of lazy keyboarders?",
                "%% - I wish I could put a few select people on mute today.",
                "%% - How about never? Is never good for you?",
                "%% - Was that a fart? It made no scents to me.",
                "%% - You are now validating my inherent mistrust of strangers.",
                "%% - Yeah, sometimes I talk to myself too, but usually only when I need expert advice."};
            Responses = new List<string>(responses);
        }

        public string DontKnowHow(string value, Connection player) {
            string response = string.Empty;
            if (!player.ResponseStack.Any()) {
                Responses.Shuffle();
                foreach (string item in Responses) {
                    player.ResponseStack.Push(item);
                }
            }
            response = player.ResponseStack.Pop();
            string command = " \"".Ansi(Style.white) + value + "\"".Ansi(Style.white, Style.yellow);
            response = response.Replace("%%", command).Ansi(Style.yellow).NewLine();
            return response;
        }
    }
   
}
