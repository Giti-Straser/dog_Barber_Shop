שלבים להרצת הפרוייקט:
1, הרצת הסקריפטים מתיקיית scripts בדאטה בייס (קודם הסקריפט של יצירת הדאטה בייס)
2, עדכון הconnectionstring מהקובץ appsettings לשלכם
3, להריץ בPackage Manager Console בבקאנד את הפקודות הבאות לפי הסדר:
   Add-Migration InitialCreate -context Dogs_burber_shopContext
   Update-Database InitialCreate -context Dogs_burber_shopContext
4, להריץ npm i בקליינט
זהו :) הפרוייקט מוכן לבדיקה