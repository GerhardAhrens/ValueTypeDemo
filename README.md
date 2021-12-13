# Was sind Value Objects?
Value Objects sind dann besonders wichtig, wenn diese im Bezug des Domain Driven Design (DDD) verwendet werden. Ein weiterer wichtiker Aspekt, ist wenn die Benutzung von Typen 
einen konkreten Bezug zu einer fachleichkeit haben soll. Strukturen, die für sich genommen keinen Sinn ergeben, aber Informationen enthalten, werden als Wertobjekte bezeichnet. 
Wir können die Datumsstruktur als Beispiel betrachten. Die Kombination von 3 Zahlen, Tag, Monat und Jahr, erzeugt Informationen, die auf ein bestimmtes Datum hinweisen. Es ist jedoch unklar, was dieses Datum bedeutet. Dieses Problem wird verständlicher, wenn wir über zwei Hauptmerkmale von Wertobjekten sprechen.

##1 —Identityless
Wertobjekte sind anonyme Einheiten. Sie enthalten also Daten, die für sich allein keinen Sinn ergeben. Betrachten wir die DateTime-Struktur, so enthält sie eine Datumsinformation. 
Wir können jedoch nicht wissen, was dieses Datum bedeutet, wenn es allein verwendet wird. Wertobjekte gewinnen an Bedeutung, wenn sie von einer Entität verwendet werden. 
Stellen wir uns einen Person oder eine Rechnung vor. Zusammen mit diesen Entitäten kann die Datumsinformation Bedeutungen wie das Geburtsdatum oder das Erstellungsdatum Rechnung haben.

##2 — Immutable
Während der Erstellung von Objekten erhalten sie über Konstruktormethoden Daten, die danach nicht mehr geändert werden können. Wir können diese Situation anhand des DateTime-Beispiels erklären. Nachdem wir das Datumsobjekt mit den Werten für Tag, Monat und Jahr erstellt haben, können wir diese Werte nicht mehr ändern. Wenn wir ein neues Datum setzen wollen, müssen wir erneut ein DateTime-Objekt erstellen.


## This Demo is written in C# for NET6
