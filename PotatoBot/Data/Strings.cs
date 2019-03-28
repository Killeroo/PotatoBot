using System;
using System.Collections.Generic;
using System.Text;
using DSharpPlus;

namespace PotatoBot.Data
{
    /// <summary>
    /// Contains static strings used by potatobot
    /// </summary>
    public class Strings
    {
        public static string[] POTATO_FACTS = {
            "Potato Fact 1: Potatoes are vegetables but they contain a lot of starch (carbohydrates) that make them more like rice, pasta and bread in terms of nutrition.",
            "Potato Fact 2: The word potato comes from the Spanish word patata.",
            "Potato Fact 3: Potato plants are usually pollinated by insects such as bumblebees.",
            "Potato Fact 4: There are thousands of different potato varieties but not all are commercially available, popular ones include Russet, Yukon Gold, Kennebec, Desiree and Fingerling.",
            "Potato Fact 5: Based on 2010 statistics, China is the leading producer of potatoes.",
            "Potato Fact 6: Potato storage facilities are kept at temperatures above 4 °C (39 °F) as potato starch turns into sugar and alters the taste below this temperature.",
            "Potato Fact 7: One of the main causes of the Great Famine in Ireland between 1845 and 1852 was a potato disease known as potato blight. The shortage of potatoes led to the death of around 1 million people who were dependent on them as a food source.",
            "Potato Fact 8: Although it shares the same name, the sweet potato is a root vegetable and only loosely related to the potato.",
            "Potato Fact 9: Potatoes are sometimes called taters, tatties or spuds.",
            "Potato Fact 10: A potato is about 80% water.",
            "Potato Fact 11: United States potato lovers consumed more than 4 million tons of French Fries in various shapes and sizes.",
            "Potato Fact 12: Potatoes are a powerful aphrodisiac, says a physician in Ireland.",
            "Potato Fact 13: The average American eats 140 pounds of potatoes per year. Germans eat more than 200 pounds per year.",
            "Potato Fact 14: The largest potato grown was 18 pounds and 4 ounces according to the Guinness Book of World Records.",
            "Potato Fact 15: Potatoes are the world’s fourth food staple – after wheat, corn and rice.",
            "Potato Fact 16: Potatoes are grown in more than 125 countries.",
            "Potato Fact 17: Every year enough potatoes are grown worldwide to cover a four-lane motorway circling the world six times.",
            "Potato Fact 18: August 19th and October 27th are National Potato Day.",
            "Potato Fact 19: Wild potato species can be found throughout the Americas, from the United States to southern Chile.",
            "Potato Fact 20: Potatoes were domesticated approximately 7,000–10,000 years ago.",
            "Potato Fact 21: Following millennia of selective breeding, there are now over 1,000 different types of potatoes.",
            "Potato Fact 22: Potatoes are used to brew alcoholic beverages such as vodka, poitín, or akvavit.",
            "Potato Fact 23: Potatoes have been delivered with personalized messages as a novelty. Potato delivery services include Potato Parcel and Mail A Spud.",
            "Potato Fact 24: Potato skins, along with honey, are a folk remedy for burns in India. Burn centres in India have experimented with the use of the thin outer skin layer to protect burns while healing.",
            "Potato Fact 25: The world dedicated 18.6 million ha (46 million acres) in 2010 for potato cultivation.",
            "Potato Fact 26: Potato diseases include Rhizoctonia, Sclerotinia, black leg, powdery mildew, powdery scab and leafroll virus.",
            "Potato Fact 27: Insects that commonly transmit potato diseases or damage the plants include the Colorado potato beetle, the potato tuber moth, the green peach aphid (Myzus persicae), the potato aphid, beet leafhoppers, thrips, and mites.",
            "Potato Fact 28: Potatoes contain toxic compounds known as glycoalkaloids, of which the most prevalent are solanine and chaconine. Glycoalkaloid poisoning may cause headaches, diarrhea, cramps, and, in severe cases, coma and death.",
            "Potato Fact 29: In the UK, potatoes are not considered by the National Health Service (NHS) as counting or contributing towards the recommended daily five portions of fruit and vegetables.",
            "Potato Fact 30: In 2016, world production of potatoes was 377 million tonnes, led by China with over 26% of the world total",
            "Potato Fact 31: The potato was first domesticated in the region of modern-day southern Peru and extreme northwestern Bolivia.",
            "Potato Fact 32: According to conservative estimates, the introduction of the potato was responsible for a quarter of the growth in Old World population and urbanization between 1700 and 1900.",
            "Potato Fact 33: The most widely cultivated variety, Solanum tuberosum tuberosum, is indigenous to the Chiloé Archipelago, and has been cultivated by the local indigenous people since before the Spanish conquest.",
            "Potato Fact 34: The earliest archaeologically verified potato tuber remains have been found at the coastal site of Ancon (central Peru), dating to 2500 BC.",
            "Potato Fact 35: Following the Spanish conquest of the Inca Empire, the Spanish introduced the potato to Europe in the second half of the 16th century, part of the Columbian exchange.",
            "Potato Fact 36: Lack of genetic diversity in potatoes, due to the very limited number of varieties that were initially introduced, left the crop vulnerable to disease and may have caused the Great Irish Famine.",
            "Potato Fact 37: Dozens of potato cultivars have been selectively bred specifically for their skin or, more commonly, flesh color, including gold, red, and blue varieties",
            "Potato Fact 38: The European Cultivated Potato Database (ECPD) is an online collaborative database of potato variety descriptions that is updated and maintained by the Scottish Agricultural Science Agency. You can find it at http://www.europotato.org/",
            "Potato Fact 39: There are close to 4,000 varieties of potato including common commercial varieties of potato.",
            "Potato Fact 40: The potato genome contains 12 chromosomes and 860 million base pairs, making it a medium-sized plant genome.",
            "Potato Fact 41: More than 99 percent of all current varieties of potatoes currently grown are direct descendants of a subspecies that once grew in the lowlands of south-central Chile.",
            "Potato Fact 42: The major species of potato grown worldwide is Solanum tuberosum.",
            "Potato Fact 43: Genetic testing of the wide variety of cultivars and wild species affirms that all potato subspecies derive from a single origin in the area of present-day southern Peru and extreme Northwestern Bolivia (from a species in the Solanum brevicaule complex).",
            "Potato Fact 44: Three thousand potato varieties are found in the Andes alone, mainly in Peru, Bolivia, Ecuador, Chile, and Colombia.",
            "Potato Fact 45: Genetic research has produced several genetically modified potato varieties. Including 'New Leaf', owned by Monsanto Company.",
            "Potato Fact 46: After flowering, potato plants produce small green fruits that resemble green cherry tomatoes, each containing about 300 seeds.",
            "Potato Fact 47: Like all parts of the potato plant except the tubers, the fruit contain the toxic alkaloid solanine and are therefore unsuitable for consumption.",
            "Potato Fact 48: The potato can bear white, pink, red, blue, or purple flowers with yellow stamens (pollen producing part of the plant).",
            "Potato Fact 49: Potatoes are mostly cross-pollinated by insects such as bumblebees, which carry pollen from other potato plants, though a substantial amount of self-fertilizing occurs as well.",
            "Potato Fact 50: The origin of the word \"spud\" has erroneously been attributed to an 18th-century activist group dedicated to keeping the potato out of Britain, calling itself The Society for the Prevention of Unwholesome Diet (S.P.U.D.).",
            "Potato Fact 51: The name spud for a small potato comes from the digging of soil (or a hole) prior to the planting of potatoes.",
            "Potato Fact 52: The word spud has an unknown origin and was originally (c. 1440) used as a term for a short knife or dagger, probably related to the Latin \"spad-\" a word root meaning \"sword\".",
            "Potato Fact 53: The 16th-century English herbalist John Gerard referred to sweet potatoes as \"common potatoes\", and used the terms \"bastard potatoes\" and \"Virginia potatoes\" for the species we now call \"potato\".",
            "Potato Fact 54: Being a nightshade similar to tomatoes, the vegetative and fruiting parts of the potato contain the toxin solanine and are not fit for human consumption.",
            "Potato Fact 55: Potatos are part of the nightshade family of plants, Their Binomial name is " + Formatter.Italic("Solanum tuberosum."),
            "Potato Fact 56: In many contexts, potato refers to the edible tuber. Tubers are enlarged structures used as storage organs for the potato plant's nutrients.",
            "Potato Fact 57: The edible part of the potato (the tuber), is used for the potato plant's perennation (survival of the winter or dry months) and to provide energy and nutrients for regrowth during the next growing season."
        };

        public static string[] MAGIC_EIGHT_BALL_RESPONSES = {
            "Signs point to yes.",
            "Yes.",
            "Without a doubt.",
            "As I see it, yes.",
            "You may rely on it.",
            "It is decidedly so.",
            "Yes - definitely.",
            "It is certain.",
            "Most likely.",
            "Outlook good.",
            "Reply hazy, try again.",
            "Concentrate and ask again.",
            "Better not tell you now.",
            "Cannot predict now.",
            "Ask again later.",
            "My sources say no.",
            "Outlook not so good.",
            "Very doubtful.",
            "My reply is no.",
            "Don't count on it."
        };
    }
}
