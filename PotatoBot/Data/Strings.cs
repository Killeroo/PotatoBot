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
            "Potatoes are vegetables but they contain a lot of starch (carbohydrates) that make them more like rice, pasta and bread in terms of nutrition.",
            "The word potato comes from the Spanish word patata.",
            "Potato plants are usually pollinated by insects such as bumblebees.",
            "There are thousands of different potato varieties but not all are commercially available, popular ones include Russet, Yukon Gold, Kennebec, Desiree and Fingerling.",
            "Based on 2010 statistics, China is the leading producer of potatoes.",
            "Potato storage facilities are kept at temperatures above 4 °C (39 °F) as potato starch turns into sugar and alters the taste below this temperature.",
            "One of the main causes of the Great Famine in Ireland between 1845 and 1852 was a potato disease known as potato blight. The shortage of potatoes led to the death of around 1 million people who were dependent on them as a food source.",
            "Although it shares the same name, the sweet potato is a root vegetable and only loosely related to the potato.",
            "Potatoes are sometimes called taters, tatties or spuds.",
            "A potato is about 80% water.",
            "United States potato lovers consumed more than 4 million tons of French Fries in various shapes and sizes.",
            "Potatoes are a powerful aphrodisiac, says a physician in Ireland.",
            "The average American eats 140 pounds of potatoes per year. Germans eat more than 200 pounds per year.",
            "The largest potato grown was 18 pounds and 4 ounces according to the Guinness Book of World Records.",
            "Potatoes are the world’s fourth food staple – after wheat, corn and rice.",
            "Potatoes are grown in more than 125 countries.",
            "Every year enough potatoes are grown worldwide to cover a four-lane motorway circling the world six times.",
            "August 19th and October 27th are National Potato Day.",
            "Wild potato species can be found throughout the Americas, from the United States to southern Chile.",
            "Potatoes were domesticated approximately 7,000–10,000 years ago.",
            "Following millennia of selective breeding, there are now over 1,000 different types of potatoes.",
            "Potatoes are used to brew alcoholic beverages such as vodka, poitín, or akvavit.",
            "Potatoes have been delivered with personalized messages as a novelty. Potato delivery services include Potato Parcel and Mail A Spud.",
            "Potato skins, along with honey, are a folk remedy for burns in India. Burn centres in India have experimented with the use of the thin outer skin layer to protect burns while healing.",
            "The world dedicated 18.6 million ha (46 million acres) in 2010 for potato cultivation.",
            "Potato diseases include Rhizoctonia, Sclerotinia, black leg, powdery mildew, powdery scab and leafroll virus.",
            "Insects that commonly transmit potato diseases or damage the plants include the Colorado potato beetle, the potato tuber moth, the green peach aphid (Myzus persicae), the potato aphid, beet leafhoppers, thrips, and mites.",
            "Potatoes contain toxic compounds known as glycoalkaloids, of which the most prevalent are solanine and chaconine. Glycoalkaloid poisoning may cause headaches, diarrhea, cramps, and, in severe cases, coma and death.",
            "In the UK, potatoes are not considered by the National Health Service (NHS) as counting or contributing towards the recommended daily five portions of fruit and vegetables.",
            "In 2016, world production of potatoes was 377 million tonnes, led by China with over 26% of the world total",
            "The potato was first domesticated in the region of modern-day southern Peru and extreme northwestern Bolivia.",
            "According to conservative estimates, the introduction of the potato was responsible for a quarter of the growth in Old World population and urbanization between 1700 and 1900.",
            "The most widely cultivated variety, Solanum tuberosum tuberosum, is indigenous to the Chiloé Archipelago, and has been cultivated by the local indigenous people since before the Spanish conquest.",
            "The earliest archaeologically verified potato tuber remains have been found at the coastal site of Ancon (central Peru), dating to 2500 BC.",
            "Following the Spanish conquest of the Inca Empire, the Spanish introduced the potato to Europe in the second half of the 16th century, part of the Columbian exchange.",
            "Lack of genetic diversity in potatoes, due to the very limited number of varieties that were initially introduced, left the crop vulnerable to disease and may have caused the Great Irish Famine.",
            "Dozens of potato cultivars have been selectively bred specifically for their skin or, more commonly, flesh color, including gold, red, and blue varieties",
            "The European Cultivated Potato Database (ECPD) is an online collaborative database of potato variety descriptions that is updated and maintained by the Scottish Agricultural Science Agency. You can find it at http://www.europotato.org/",
            "There are close to 4,000 varieties of potato including common commercial varieties of potato.",
            "The potato genome contains 12 chromosomes and 860 million base pairs, making it a medium-sized plant genome.",
            "More than 99 percent of all current varieties of potatoes currently grown are direct descendants of a subspecies that once grew in the lowlands of south-central Chile.",
            "The major species of potato grown worldwide is Solanum tuberosum.",
            "Genetic testing of the wide variety of cultivars and wild species affirms that all potato subspecies derive from a single origin in the area of present-day southern Peru and extreme Northwestern Bolivia (from a species in the Solanum brevicaule complex).",
            "Three thousand potato varieties are found in the Andes alone, mainly in Peru, Bolivia, Ecuador, Chile, and Colombia.",
            "Genetic research has produced several genetically modified potato varieties. Including 'New Leaf', owned by Monsanto Company.",
            "After flowering, potato plants produce small green fruits that resemble green cherry tomatoes, each containing about 300 seeds.",
            "Like all parts of the potato plant except the tubers, the fruit contain the toxic alkaloid solanine and are therefore unsuitable for consumption.",
            "The potato can bear white, pink, red, blue, or purple flowers with yellow stamens (pollen producing part of the plant).",
            "Potatoes are mostly cross-pollinated by insects such as bumblebees, which carry pollen from other potato plants, though a substantial amount of self-fertilizing occurs as well.",
            "The origin of the word \"spud\" has erroneously been attributed to an 18th-century activist group dedicated to keeping the potato out of Britain, calling itself The Society for the Prevention of Unwholesome Diet (S.P.U.D.).",
            "The name spud for a small potato comes from the digging of soil (or a hole) prior to the planting of potatoes.",
            "The word spud has an unknown origin and was originally (c. 1440) used as a term for a short knife or dagger, probably related to the Latin \"spad-\" a word root meaning \"sword\".",
            "The 16th-century English herbalist John Gerard referred to sweet potatoes as \"common potatoes\", and used the terms \"bastard potatoes\" and \"Virginia potatoes\" for the species we now call \"potato\".",
            "Being a nightshade similar to tomatoes, the vegetative and fruiting parts of the potato contain the toxin solanine and are not fit for human consumption.",
            "Potatos are part of the nightshade family of plants, Their Binomial name is " + Formatter.Italic("Solanum tuberosum."),
            "In many contexts, potato refers to the edible tuber. Tubers are enlarged structures used as storage organs for the potato plant's nutrients.",
            "The edible part of the potato (the tuber), is used for the potato plant's perennation (survival of the winter or dry months) and to provide energy and nutrients for regrowth during the next growing season."
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
