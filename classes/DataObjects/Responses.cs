using System.Linq;
using System.Collections.Generic;
using Mountain.classes.tcp;
using Mountain.classes.functions;


namespace Mountain.classes.dataobjects {

    public class StringResponses {
        public List<string> Responses;

        public StringResponses() {
            PopulateLists();
        }

        private void PopulateLists() {
            string[] responses = {
                "I really don't know what to do with %%.",
                "You know, I really don't recall %% at the moment, but if I try teleporting you there real quick, we could have some fun finding out, ok?",
                "I work very hard behind the scenes to keep you happy you know, so can I, pretty please, do two quick and mostly painless %%'s on you now?",
                "No, my powers can only be used for good, so stop asking me to %% for you.",
                "You'd think I'd know why you'd want me to do %% for you by now wouldn't you.",
                "Yes, I'm an agent of Satan too, but my duties are a bit more ceremonial than what your %% duties seem to entail.",
                "I'm starting to visualize the %% that's now dripping over your keyboard. Try to keep it at your end, huh?",
                "I don't know the medical term for your finger problems, but I'll bet it's as hard to pronounce as %% is for me to try and do.",
                "If I knew what to do with %% I'd still maybe not do it for you.. *eyes you suspiciously*.",
                "I've known you for what.. at least since you've logged on, and you are already asking me to %%??",
                "I'm definitely not gonna try and imagine what %% is.",
                "Would you actually %% if you were me? I'd definitely not do it if I were you, which, very thankfully, I'm not.",
                "I've tried %% before and somehow you're still here. Where's my bigger fly swatter..",
                "Sure, do this %% you say, and just how would you expect me to actually go about doing it?",
                "Yeah, right, %%, I can't even begin to think why you'd ever mention it in here out loud.",
                "*Blink* I have but two brain cells left since you've come on, (one trying to push the other around in a wheelchair) so maybe you could explain %%?",
                "Yeah, %%, like I didn't see that one coming.",
                "I seem to have lost my %% wand once again, so very sorry.. *roll*.",
                "I'm absolutely sure there's a dictionary with %% in it somewhere.",
                "You don't remember what happened the last time you wanted to %%??",
                "Alrighty.. %%.. sure.. let me find my magic what's-its-wand first though.",
                "I'm just not gonna do %% for you. Nope, no way, not ever, not again.",
                "No problem, I seem to remember doing %% successfully in my sleep, just a sec...zzzz..",
                "%% - You should really come with a warning label.",
                "%% - Now that's just plain silly. Stop messing with me!..go away even!!..*sigh*...let me put something on first then ok?",
                "%% - Maybe, if you started treating me like the god I am, I'd find a way to actually do this weird request of yours.",
                "%% - Humph.. I see typing isn't one of our strong suits now is it.",
                "%% - Drinking again are we?",
                "%% - Give me a break. And put some cloths on before you type anything else! Sheesh!",
                "%%.. OK, now you've got me having a giggly fit.",
                "%% - *blush*",
                "%% - last time I tried that my eyes teared up.",
                "%% - You really, really want me to teleport you around a good bit now don't you.",
                "%% - OK, now my palm is itchy terribly.",
                "%% - How many times do I have to tell you to stop trying that.",
                "%% - Sure, and for a nickel I'll throw in a pink four leaf clover.",
                "%% - .. well it isn't my sanity thats on the line here now is it.",
                "%% - umm..some advice.. on the keyboard of life, always keep one finger on the escape key and both elbows far away from the rest.",
                "%% - umm..my five levels of reality checks have somehow bounced.",
                "%% - I'm not sure that's such a good idea, *eyes you with surprise*.",
                "%% - You're sounding rather reasonable.. Must be time to up my meds.",
                "%% - *blink*.. someday we'll look back on that, laugh nervously and change the subject.",
                "%% - You actually mean for me to do that right this very minute, don't you.",
                "%% - I know you only drink alcohol to make me seem more interesting.. how's that been working for you?",
                "%% - so just what is it we're smoking today? I do hope you brought extra.",
                "%% - I know you're not slurring your words, you're just talking cursively again.",
                "%% - You did say you went to school right?",
                "%% - I wish I could put a few select people on mute.",
                "%% - How about never? Is never good for you?",
                "%% - Was that a fart? It made no scents to me.",
                "%% - You are definitely validating my inherent mistrust of strangers.",
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
