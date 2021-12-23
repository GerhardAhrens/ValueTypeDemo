# Value Objects <img src="./ValueObject.png" style="width:50px;"/>
## This Demo is written in C# for NET5

# Was sind Value Objects?
Value Objects (VO) sind dann besonders wichtig, wenn diese im Bezug des Domain Driven Design (DDD) verwendet werden. Ein weiterer wichtiger Aspekt, ist wenn die Benutzung von Typen 
einen konkreten Bezug zu einer Fachlichkeit haben soll. Strukturen, die für sich genommen keinen Sinn ergeben, aber Informationen enthalten, werden als Wertobjekte bezeichnet. 
Wir können die Datumsstruktur als Beispiel betrachten. Die Kombination von 3 Zahlen, Tag, Monat und Jahr, erzeugt Informationen, die auf ein bestimmtes Datum hinweisen. Es ist jedoch unklar, was dieses Datum bedeutet. Dieses Problem wird verständlicher, wenn wir über zwei Hauptmerkmale von Wertobjekten sprechen.

## 1 —Identityless
Wertobjekte sind anonyme Einheiten. Sie enthalten also Daten, die für sich allein keinen Sinn ergeben. Betrachten wir die DateTime-Struktur, so enthält sie eine Datumsinformation. 
Wir können jedoch nicht wissen, was dieses Datum bedeutet, wenn es allein verwendet wird. Wertobjekte gewinnen an Bedeutung, wenn sie von einer Entität verwendet werden. 
Stellen wir uns einen Person oder eine Rechnung vor. Zusammen mit diesen Entitäten kann die Datumsinformation Bedeutungen wie das Geburtsdatum oder das Erstellungsdatum Rechnung haben.

## 2 — Immutable
Während der Erstellung von Objekten erhalten sie über Konstruktormethoden Daten, die danach nicht mehr geändert werden können. Wir können diese Situation anhand des DateTime-Beispiels erklären. Nachdem wir das Datumsobjekt mit den Werten für Tag, Monat und Jahr erstellt haben, können wir diese Werte nicht mehr ändern. Wenn wir ein neues Datum setzen wollen, müssen wir erneut ein DateTime-Objekt erstellen.

## Beispiel
```
class Person
{
    string Name;
    int BirthDate_Year;
    int BirthDate_Month;
    int BirthDate_Date;
}

class Person
{
    Name Name;
    Birthday BirthDate;
}
```
Betrachtet man die obigen Beipiele, so ist das zweite Beispiel der Person-Klasse besser lesbar. Im in diesem Beispiel wird am deutlichsten wie ValueObjects einzusetzten werden können. Die Darstellung der Informationen wirkt sich positiv auf die Wartbarkeit des Codes aus.

## Sicherheit in der parallelen Programmierung
Während der parallelen Codeausführung kann es vorkommen, dass verschiedene Threads die Werte, die Objekte tragen, ändern wollen. In diesem Fall tritt eine "Race Condition" auf. Aufgrund der "Race Condition" kann das Programm bei jeder Ausführung unterschiedliche Ergebnisse liefern. Da Wertobjekte unveränderlich sind, können sie keine "Race Condition" auslösen.

## Vor- und Nachteile von Value Objects
Bei der Verwendung von Value Objects (VO) sehe ich folgende wichtige Vorteile
- Konkrete Beschreibung eines Wertes
- Erweiterungen, die nur auf diesem Typ wirken (z.B. durch Extensions)
- Value Objects können nach dem Erstellen nicht mehr geändert werden (Immutable)

Bei den Nachteilen wäre zu nennen den Aufwand zur Erstellung von Value Objects (hier kann zumindest über T4-Templates die Erstellung vereinfacht werden) den den damit verbundenen Test, dieser sehr ausführlich sein sollte da die Value Objects in der gesammten Applikation verwendet werden.
Weiter gibt es sicher auch Situationen, das eine Value Objects nach dem Erstellen geändert werden muß. Hier müssen dann nachträglich sepzielle Methoden erstellt werden.
Value Objects müssen vor der Verwendung instanziert werden, das immer eine gewisse Zeit und damit auch Performance kostet. Hier sind die Vor- und Nachteile abzuwägen.

## Opertoren Überladung (overload operators)
Wir wollen die VO wie Typen verwenden. Daher wollen wir auch die Operatoren wie '==', '!=' usw verwenden. Die Basisklasse 'ValueObjectBase' stellt die Anweisungen für Vergleiche als Methoden zur Verfügung.
In unserem VO müssen dann die gewünschten Operatoren entsprechend überladen werden.
```
public static bool operator == (Email a, Email b)
{
     return EqualOperator(a.Value, b.Value);
}
```
Wichtig hier, das wir nicht zwei Objekte vergleichen wollen, sondern einen bestimmten Wert in diesem Objekt. In diesem Fall das Property 'Value'.

## Beispiel für ein VO EMail Adresse

In diesem einfachen Beispiel gibt es ein VO Email das intern auch prüft, ob die angegebene EMail-Adresse auch formal valide ist. Properties können nur gelesen werden.
```
Email email = new Email("developer@lifeprojects.de");
bool emailValid = email.IsConfirmed;
string emalAddress = email.Value;

// Vergleichen zweier Emal-Adressen
Email emailA = new Email("developer@lifeprojects.de");
Email emailB = new Email("developer@lifeprojects.de");
if (emailA == emailB)
{
    // beide Adressen sind gleich
}
```

## Beispiel für ein VO Birthday
C# hat einen allgemeinen DateTime Typ, so ist es auch möglich mit einem VO eine speziellen Birthday Typ zu erstellen. Dieser Typ hat dann Merkmale die nur im zusammenhang 
mit einem Geburtstagsdatum benötig werden, wie z.B. das Alter in Jahren, Tagen usw.
