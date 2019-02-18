using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Configuration;
using WordHolders;

public class WordGetter
{
    public WordGetter(string ThesaurusWord, out string wordout, out List<string> listout)
    {
        wordout = ThesaurusWord;


        string apikey = ConfigurationManager.AppSettings.Get("apikey");
        string url = ConfigurationManager.AppSettings.Get("apiurl");
        string responsetype = ConfigurationManager.AppSettings.Get("responsetype");

        WebRequest request = WebRequest.Create(url + apikey + "/" + ThesaurusWord + "/" + responsetype);

        //JObject jdocs = new JObject();

        RootObject rowords = new RootObject();



        try
        {
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream stream = response.GetResponseStream();

            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            string responseString = reader.ReadToEnd();

            rowords = JsonConvert.DeserializeObject<RootObject>(responseString);

            //jdocs = JObject.Parse(responseString);


            response.Close();
            stream.Close();

        }
        catch (WebException)
        {
        }

        var wordlist = new List<string>();

        var nounlist = new List<string>();

        //Console.WriteLine(rowords.noun.syn[0]);

        try
        {
            //JArray jdocnoun = (JArray)jdocs["noun"]["syn"];
            //nounlist = jdocnoun.ToObject<List<string>>();
            nounlist = nounlist = rowords.noun.syn;
            wordlist = wordlist.Concat(nounlist).ToList();
        }
        catch (NullReferenceException)
        {
            //Console.WriteLine("\nNo nouns found!");
        }


        var verblist = new List<string>();

        try
        {
            //JArray jdocverb = (JArray)jdocs["verb"]["syn"];
            //verblist = jdocverb.ToObject<List<string>>();
            verblist = rowords.verb.syn;
            wordlist = wordlist.Concat(verblist).ToList();
        }
        catch (NullReferenceException)
        {
            //Console.WriteLine("\nNo verbs found!");
        }

        var adverblist = new List<string>();

        try
        {
            //JArray jdocadverb = (JArray)jdocs["adverb"]["syn"];
            //adverblist = jdocadverb.ToObject<List<string>>();
            adverblist = rowords.adverb.syn;
            wordlist = wordlist.Concat(adverblist).ToList();

        }
        catch (NullReferenceException)
        {
            // Console.WriteLine("\nNo adverbs found!");
        }

        var adjectivelist = new List<string>();

        try
        {
            //JArray jdocadjective = (JArray)jdocs["adjective"]["syn"];
            //adjectivelist = jdocadjective.ToObject<List<string>>();
            adjectivelist = rowords.adjective.syn;
            wordlist = wordlist.Concat(adjectivelist).ToList();

        }
        catch (NullReferenceException)
        {
            //Console.WriteLine("\nNo adjective found!");
        }

        var conjunctionlist = new List<string>();

        try
        {
            //JArray jdocconjunction = (JArray)jdocs["conjunction"]["syn"];
            //conjunctionlist = jdocconjunction.ToObject<List<string>>();
            conjunctionlist = rowords.conjunction.syn;
            wordlist = wordlist.Concat(conjunctionlist).ToList();

        }
        catch (NullReferenceException)
        {
            //Console.WriteLine("\nNo conjunction found!");
        }


        var prepositionlist = new List<string>();

        try
        {
            //JArray jdocpreposition = (JArray)jdocs["preposition"]["syn"];
            //prepositionlist = jdocpreposition.ToObject<List<string>>();
            prepositionlist = rowords.preposition.syn;
            wordlist = wordlist.Concat(prepositionlist).ToList();

        }
        catch (NullReferenceException)
        {
            //Console.WriteLine("\nNo preposition found!");
        }

        var pronounlist = new List<string>();

        try
        {
            //JArray jdocpronoun = (JArray)jdocs["pronoun"]["syn"];
            //pronounlist = jdocpronoun.ToObject<List<string>>();
            wordlist = wordlist.Concat(pronounlist).ToList();
            pronounlist = rowords.pronoun.syn;
        }
        catch (NullReferenceException)
        {
            //Console.WriteLine("\nNo pronoun found!");
        }

        var interjectionlist = new List<string>();

        try
        {
            //JArray jdocinterjection = (JArray)jdocs["interjection"]["syn"];
            //interjectionlist = jdocinterjection.ToObject<List<string>>();
            wordlist = wordlist.Concat(interjectionlist).ToList();
            interjectionlist = rowords.interjection.syn;
        }
        catch (NullReferenceException)
        {
            //Console.WriteLine("\nNo interjection found!");
        }


        listout = wordlist;

    }
}
