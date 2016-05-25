﻿Bridge.merge(new System.Globalization.CultureInfo("xh", true), {
    englishName: "isiXhosa",
    nativeName: "isiXhosa",

    numberFormat: Bridge.merge(new System.Globalization.NumberFormatInfo(), {
        naNSymbol: "NaN",
        negativeSign: "-",
        positiveSign: "+",
        negativeInfinitySymbol: "-Infinity",
        positiveInfinitySymbol: "Infinity",
        percentSymbol: "%",
        percentGroupSizes: [3],
        percentDecimalDigits: 2,
        percentDecimalSeparator: ".",
        percentGroupSeparator: ",",
        percentPositivePattern: 2,
        percentNegativePattern: 2,
        currencySymbol: "R",
        currencyGroupSizes: [3],
        currencyDecimalDigits: 2,
        currencyDecimalSeparator: ".",
        currencyGroupSeparator: ",",
        currencyNegativePattern: 2,
        currencyPositivePattern: 2,
        numberGroupSizes: [3],
        numberDecimalDigits: 2,
        numberDecimalSeparator: ".",
        numberGroupSeparator: ",",
        numberNegativePattern: 1
    }),

    dateTimeFormat: Bridge.merge(new System.Globalization.DateTimeFormatInfo(), {
        abbreviatedDayNames: ["iCa.","uMv.","uLwesib.","uLwesith.","uLwesin.","uLwesihl.","uMgq."],
        abbreviatedMonthGenitiveNames: ["uJan.","uFeb.","uMat.","uEpr.","uMey.","uJun.","uJul.","uAg.","uSep.","uOkt.","uNov.","uDis.",""],
        abbreviatedMonthNames: ["uJan.","uFeb.","uMat.","uEpr.","uMey.","uJun.","uJul.","uAg.","uSep.","uOkt.","uNov.","uDis.",""],
        amDesignator: "Ekuseni",
        dateSeparator: "/",
        dayNames: ["iCawa","uMvulo","uLwesibini","uLwesithathu","uLwesine","uLwesihlanu","uMgqibelo"],
        firstDayOfWeek: 0,
        fullDateTimePattern: "dd MMMM yyyy hh:mm:ss tt",
        longDatePattern: "dd MMMM yyyy",
        longTimePattern: "hh:mm:ss tt",
        monthDayPattern: "d MMMM",
        monthGenitiveNames: ["uJanuwari","uFebuwari","uMatshi","uAprili","uMeyi","uJuni","uJulayi","uAgasti","uSeptemba","uOktobha","uNovemba","uDisemba",""],
        monthNames: ["uJanuwari","uFebuwari","uMatshi","uAprili","uMeyi","uJuni","uJulayi","uAgasti","uSeptemba","uOktobha","uNovemba","uDisemba",""],
        pmDesignator: "Emva Kwemini",
        rfc1123: "ddd, dd MMM yyyy HH':'mm':'ss 'GMT'",
        shortDatePattern: "yyyy/MM/dd",
        shortestDayNames: ["Ca","Mv","Lb","Lt","Ln","Lh","Mg"],
        shortTimePattern: "hh:mm tt",
        sortableDateTimePattern: "yyyy'-'MM'-'dd'T'HH':'mm':'ss",
        sortableDateTimePattern1: "yyyy'-'MM'-'dd",
        timeSeparator: ":",
        universalSortableDateTimePattern: "yyyy'-'MM'-'dd HH':'mm':'ss'Z'",
        yearMonthPattern: "MMMM yyyy",
        roundtripFormat: "yyyy'-'MM'-'dd'T'HH':'mm':'ss.uzzz"
    })
});
