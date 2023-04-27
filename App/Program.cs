using System.Text.RegularExpressions;

string sentence = @"?
  c??????@@??T1011111113bbbP002002001004D  D  MM 9008CAI     45022AA5111AN5028BEA5027BASTR5025D-00000  BASTADT5043123455011J5006P5023EURRT1503501F  GRZ HER50141 4  0209230909231,2,3,45999510201HAUER/KAREEM5009020998   02DRUECKER/BETHANN     020998   03DLIND/GLEN5011020907   04KPURDY/MARTY50090209145451INVALID@muratsahin.co5025AUER/KAREEM5029RUECKER/BETHANN5025LIND/GLEN5031PURDY/MARTY56311 H5020AUER5016KAREEM5016020998  SONS50542 D5020RUECKER5013BETHANN5015020998  SONS50543 D5020LIND5016GLEN5018020907  SONS50544 K5020PURDY5015MARTY5017020914  SONS599959995639?  ???????@@??T1011111113bbbP002002001004D  D  G  9002CAI     25135AN5028BEA5027BASTR5025D-00000  BASTADT5043123455011J5006P5023EURIT1503501F  NUE PMI50141 2  0205230705231-25999510601DDEFAULTB/DEFAULTA   250492   02DDEFAULTD/DEFAULTC   2504925515INVALID@muratsahin.co5025DEFAULTB/DEFAULTA5023DEFAULTD/DEFAULTC57051 D5020DEFAULTB5012DEFAULTA5014250492  SONS50542 D5020DEFAULTD5012DEFAULTC5014250492  SONS599959995901";

string pattern = @"\?.+?@@\?\?T[1-3]";  
 
MatchCollection matches = Regex.Matches(sentence, pattern);
Console.WriteLine(matches.Count);
foreach (Match match in matches)
{
    Console.WriteLine(match.Value);
}

Console.WriteLine("----------");

var splitList = Regex.Split(sentence, pattern).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

var matchFlat = 0;
for (int i = 0; i < splitList.Length; i++)
{
    if (splitList[i].Length > 15)
    {
        var mtch = matches[i- matchFlat].ToString();
        var header = mtch.Substring(0, mtch.Length - 2);
        var cntnt = mtch.Substring(mtch.Length - 2, 2) + splitList[i];

        Console.WriteLine($"matches : {matches[i - matchFlat]}");
        Console.WriteLine($"splitList : {splitList[i]}");
        Console.WriteLine($"header : {header}");
        Console.WriteLine($"cntnt : {cntnt}");
        Console.WriteLine("-----------------------");
    }
    else
    {
        matchFlat++;
    }
}

 

Console.ReadLine();