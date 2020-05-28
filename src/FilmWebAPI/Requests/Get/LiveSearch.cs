using FilmWebAPI.Core;
using FilmWebAPI.Core.Communication;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace FilmWebAPI.Requests.Get
{
    public class LiveSearch : ContentRequestBase<LiveSearchResult>
    {
        private const string SEARCH_URL = "http://www.filmweb.pl/search/live";
        private readonly string _query;

        public LiveSearch(string query)
        {
            _query = query ?? throw new ArgumentNullException(nameof(query));
        }

        public override HttpRequestMessage GetRequestMessage()
        {
            return new HttpRequestMessage(HttpMethod.Get, $"{SEARCH_URL}?q={_query}");
        }

        public override async Task<LiveSearchResult> Parse(string content)
        {
            return new AdvancedLiveSearchParser().Parse(content, _query);

        }
        private class AdvancedLiveSearchParser
        {
            public LiveSearchResult Parse(string content, string query)
            {
                return new LiveSearchResult();
            }
        }
    }

    public class LiveSearchResult
    {
        public List<string> Films { get; }
        public List<string> Serials { get; }
        public List<string> Persons { get; }
    }
}





//groupSplitKey = '\a';
//maxResults = 6;

//prepare: function(e, a)
//{ // e odpowiedz z serwera // a query
//    var t, n, l, r, o = e.split(this.groupSplitKey), c = o.length > this.config.maxResults ? this.config.maxResults : o.length, p = "", h = 0;
//    c = o.length > this.config.maxResults ? this.config.maxResults : "" == o[0] ? 0 : o.length;
//    var u, f, m = {
//        f: function(s) {
//        return s[4].toLowerCase().indexOf(a) >= 0 ? (l = s[4],
//            r = s[3]) : s[3].toLowerCase().indexOf(a) >= 0 ? (l = s[3],
//                r = s[4]) : s[5].toLowerCase().indexOf(a) >= 0 ? (l = s[5],
//                    r = "" != s[4] ? s[4] : s[3]) : "" != s[4] ? (l = s[4],
//                        r = "" != s[3] ? s[3] : "") : (l = s[3],
//                            r = ""),
//                n = "" != s[2] ? '<li><div class="lsImg"><img src="' + IRI.paths.repo.f + s[2] + '"></div>' : '<li><div class="lsImg"><span class="syg"><img src="https://2.fwcdn.pl/gf/beta/ic/plugs/v01/plug.svg"></span></div>',
//                n += '<div class="resData"><a class="ls-title" href="/film/' + encodeURIComponent(l).replace(/ (% 20 |% 2F |% 3B) / g, "+") +"-" + s[6] + "-" + s[1] + '"><span class="phr">' + l + '</span>  <span class="fYear">(' + s[6] + ")</span></a>",
//                "" != r && (n += '<span class="subOtherTitle phr">' + r + "</span>"),
//                n += '<span class="caption">' + s[7] + "</span></div></li>"
//        },
//        s: function(s) {
//        return s[4].toLowerCase().indexOf(a.replace(/\s / g, "")) >= 0 ? (l = s[4],
//            r = s[3]) : s[3].toLowerCase().indexOf(a.replace(/\s / g, "")) >= 0 ? (l = s[3],
//                r = s[4]) : s[5].toLowerCase().indexOf(a.replace(/\s / g, "")) >= 0 ? (l = s[5],
//                    r = "" != s[4] ? s[4] : s[3]) : "" != s[4] ? (l = s[4],
//                        r = "" != s[3] ? s[3] : "") : (l = s[3],
//                            r = ""),
//                n = "" != s[2] ? '<li><div class="lsImg"><img src="' + IRI.paths.repo.f + s[2] + '"></div>' : '<li><div class="lsImg"><span class="syg"><img src="https://2.fwcdn.pl/gf/beta/ic/plugs/v01/plug.svg"></span></div>',
//                n += '<div class="resData"><a class="ls-title" href="/serial/' + encodeURIComponent(l).replace(/ (% 20 |% 2F |% 3B) / g, "+") +"-" + s[6] + "-" + s[1] + '"><span class="phr">' + l + '</span> <span class="fYear">(' + s[6] + ')</span> <span class="fType">serial</span></a>',
//                "" != r && (n += '<span class="subOtherTitle phr">' + r + "</span>"),
//                n += '<span class="caption">' + s[7] + "</span></div></li>"
//        },
//        tv: function(s) {
//        return s[4].toLowerCase().indexOf(a) >= 0 ? (l = s[4],
//            r = s[3]) : s[3].toLowerCase().indexOf(a) >= 0 ? (l = s[3],
//                r = s[4]) : s[5].toLowerCase().indexOf(a) >= 0 ? (l = s[5],
//                    r = "" != s[4] ? s[4] : s[3]) : "" != s[4] ? (l = s[4],
//                        r = "" != s[3] ? s[3] : "") : (l = s[3],
//                            r = ""),
//                n = "" != s[2] ? '<li><div class="lsImg"><img src="' + IRI.paths.repo.f + s[2] + '"></div>' : '<li><div class="lsImg"><span class="syg"><img src="https://2.fwcdn.pl/gf/beta/ic/plugs/v01/plug.svg"></span></div>',
//                n += '<div class="resData"><a class="ls-title" href="/film/' + encodeURIComponent(l).replace(/ (% 20 |% 2F |% 3B) / g, "+") +"-" + s[6] + "-" + s[1] + '"><span class="phr">' + l + '</span> <span class="fYear">(' + s[6] + ')</span> <span class="fType">program</span></a>',
//                "" != r && (n += '<span class="subOtherTitle phr">' + r + "</span>"),
//                n += '<span class="caption">' + s[7] + "</span></div></li>"
//        },
//        g: function(s) {
//        return s[4].toLowerCase().indexOf(a.replace(/\s / g, "")) >= 0 ? (l = s[4],
//            r = s[3]) : s[3].toLowerCase().indexOf(a.replace(/\s / g, "")) >= 0 ? (l = s[3],
//                r = s[4]) : s[5].toLowerCase().indexOf(a.replace(/\s / g, "")) >= 0 ? (l = s[5],
//                    r = "" != s[4] ? s[4] : s[3]) : "" != s[4] ? (l = s[4],
//                        r = "" != s[3] ? s[3] : "") : (l = s[3],
//                            r = ""),
//                n = "" != s[2] ? '<li><div class="lsImg"><img src="' + IRI.paths.repo.f + s[2] + '"></div>' : '<li><div class="lsImg"><span class="syg"><img src="https://2.fwcdn.pl/gf/beta/ic/plugs/v01/plug.svg"></span></div>',
//                n += '<div class="resData"><a class="ls-title" href="/videogame/' + encodeURIComponent(l).replace(/ (% 20 |% 2F |% 3B) / g, "+") +"-" + s[6] + "-" + s[1] + '"><span class="phr">' + l + '</span> <span class="fYear">(' + s[6] + ')</span> <span class="fType">gra</span></a>',
//                "" != r && (n += '<span class="subOtherTitle phr">' + r + "</span>"),
//                n += "</div></li>"
//        },
//        p: function(s) {
//        n = "" != s[2] ? '<li><div class="lsImg"><img src="' + IRI.paths.repo.p + s[2] + '"></div>' : '<li><div class="lsImg fNoImg0"><span class="syg"><img src="https://2.fwcdn.pl/gf/beta/ic/plugs/v01/plug.svg"></span></div>',
//                n += '<div class="resData"><a class="ls-title phr" href="/person/' + encodeURIComponent(s[3]).replace(/ (% 20 |% 2F |% 3B) / g, "+") +"-" + s[1] + '">' + s[3] + "</a>";
//        try
//        {
//            if (0 != s[5])
//                void 0 !== (e = d.professions[s[5]][s[4]]) && "" != e || (e = d.professions[s[5]][0]);
//                else
//                var e = "Osoba"
//            }
//        catch (s)
//        {
//            i.a.log(s)
//            }
//        return n += '<span class="caption">' + e + ("" != e && "" != s[6] ? ", " : "") + s[6] + "</span></div></li>"
//        },
//        a: function(s) {
//        return n = "<li>",
//                "" != s[2] && (n += '<div class="lsImg awardImg"><img src="' + IRI.paths.repo.a + s[2] + '" style="height: auto;width: auto;"></div>'),
//                n += '<div class="resData"><a class="ls-title phr" href="/entityLink?entityName=awardOrganization&id=' + s[1] + '">' + s[3] + "</a>",
//                n += '<span class="caption">' + s[4] + "<br>nagroda</span></div></li>"
//        },
//        c: function(s) {
//        var e = "";
//        return e = / Multikino /.test(s[2]) ? "cinema__thumbnail--search cinema__thumbnail--multikino" : / Cinema City /.test(s[2]) ? "cinema__thumbnail--search cinema__thumbnail--cinemaCity" : / Helios /.test(s[2]) ? "cinema__thumbnail--search cinema__thumbnail--helios" : "cinema__thumbnail--search cinema__thumbnail--basic",
//                n = '<li><div class="lsImg cinema__thumbnail ' + e + ' "></div>',
//                n += '<div class="resData"><span class="ls-title"><a href="/entityLink?entityName=cinema&id=' + s[1] + '" class="phr"">' + s[2] + "</a> (" + s[3] + ")</span>",
//                n += '<span class="caption">' + s[4] + "<br>kino</span></div></li>"
//        },
//        t: function(e) {
//        return n = '<li><div class="lsImg channelImg"><img class="tvChannelIco" alt="" src="' + s.config.channelIcoPathBase + "/" + e[1] + '.1.png"/></div>',
//                n += '<div class="resData"><a href="/entityLink?entityName=channel&id=' + e[1] + '" class="phr ls-title">' + e[2] + "</a>",
//                n += '<span class="caption">kanał tv</span></div></li>'
//        },
//        r: function(s) {
//        var e = '<button class="adClose" title="' + d.hideAds + '">' + (s[11] || "reklama") + ' <i class="ir ifw-cross s-12"></i></button>'
//            , a = s[5].replace("[timestamp]", +new Date);
//        return n = '<li class="lsAd"><div class="lsImg"><img alt="" src="' + s[2] + '"/></div>',
//                n += '<div class="resData"><a href="' + a + '" class="phr ls-title">' + s[3] + "</a>",
//                n += '<span class="caption">' + s[4],
//                "" != s[12] && (n += '<img class="logo" alt="" src="' + s[12] + '"/>'),
//                n += "</span>" + e + "</div></li>"
//        },
//        rn: function(s) {
//        var e = '<button class="adClose" title="' + d.hideAds + '">' + (s[11] || "reklama") + ' <i class="ir ifw-cross s-12"></i></button>'
//            , a = s[5].replace("[timestamp]", +new Date);
//        return n = '<li class="lsAd lsAd--logo"><div class="lsImg"><img alt="" src="' + s[2] + '"/></div>',
//                n += '<div class="resData"><img class="logo" alt="" src="' + s[12] + '">',
//                n += '<span class="caption"><a href="' + a + '" class="phr ls-title">' + s[3] + "</a>",
//                n += "</span>" + e + "</div></li>"
//        },
//        ml: function(s) {
//        return n = '<li><div class="lsImg"><img src="' + IRI.paths.gfx + '/beta/ic/logo_49x70.jpg"></div>',
//                n += '<div class="resData"><a class="ls-title phr" href="' + s[2] + '">' + s[1] + "</a>",
//                n += '<span class="caption">strona</span></div></li>'
//        },
//        ms: function(s) {
//        if (s[4])
//            s[4];
//        var e = s[3] || IRI.paths.gfx + "/beta/ic/logo_49x70.jpg";
//        return n = '<li><div class="lsImg"><img src="' + e + '"></div>',
//                n += '<div class="resData"><a class="ls-title phr" href="' + s[2] + '">' + s[1] + "</a>",
//                n += '<span class="caption">materiał sponsorowany</span></div></li>'
//        },
//        mp: function(s) {
//        var e = s[3] || IRI.paths.gfx + "/beta/ic/logo_49x70.jpg";
//        return n = '<li><div class="lsImg"><img src="' + e + '"></div>',
//                n += '<div class="resData"><a class="ls-title phr" href="' + s[2] + '">' + s[1] + "</a>",
//                n += '<span class="caption">materiał partnerski</span></div></li>'
//        },
//        msss: function(s) {
//        var e = s[3] || IRI.paths.gfx + "/beta/ic/logo_49x70.jpg";
//        return n = '<li><div class="lsImg"><img src="' + e + '"></div>',
//                n += '<div class="resData"><a class="ls-title phr" href="' + s[2] + '">' + s[1] + "</a>",
//                n += '<span class="caption">sekcja specjalna - materiał sponsorowany</span></div></li>'
//        },
//        u: function(s) {
//        var e = ""
//            , t = "";
//        return n = '<li><div class="lsImg" rel="' + s[5] + '">',
//                n += '<img class="lsUserAv" src="' + s[4].replace(".0.jpg", ".3.jpg") + '">',
//                n += "</div>",
//                "" != s[2] && s[1].toLowerCase().indexOf(a.replace(/\s / g, "")) >= 0 ? (e = s[1],
//                    t = s[2]) : "" != s[2] ? (e = s[2],
//                        t = s[1]) : (e = s[1],
//                            t = ""),
//                n += '<div class="resData"><a class="ls-title" href="/user/' + s[1] + '"><span class="phr">' + e + "</span></a>",
//                "" != t && (n += '<span class="subOtherTitle phr">' + t + "</span>"),
//                n += '<span class="caption">znajomy</span></div></li>'
//        }
//}, g = 0;
//    if ("film" != a || 0 == o.length)
//        for (var v in s.additionalLinks)
//            (0 == (f = v.toLowerCase().indexOf(a)) || f > 0 && " " == v.toLowerCase().substr(f - 1, 1)) && (u = s.additionalLinks[v],
//                (v.toLowerCase() == a || a.length >= s.config.minLengthAdditionalSearch) && (p += m[u[0]] (u),
//                    g++));
//    else
//        void 0 !== (u = s.additionalLinks[a]) && (p += m[u[0]] (u),
//            g++);
//    if (g > 0 || c > 0 && 0 != e.indexOf("ERROR:") && "" != o[0]) {
//        for (; h<c; h++)
//            void 0 !== m[(t = o[h].split(this.splitKey))[0]] && this.showResultWithAd(t[1]) && (p += m[t[0]](t));
//        return {
//result: p += this.config.seeAllButton.replace(/@{ phrase}/ g, a),
//            count: c + g
//        }
//}
//    return this.showError(e.replace("ERROR:", "")),
//        !1
//},