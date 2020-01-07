using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DialoghiLivello1
{
    public static string[] dialoghi = new string[] {
        "Protagonista;Nel 2035 le più grandi città erano delle discariche a cielo aperto",
        "Bambino;A cosa era dovuta questa situazione?",
        "Protagonista;Era una conseguenza indiretta di alcuni problemi iniziati con la seconda rivoluzione industriale…", 
        ";",
        //#DOMANDA 1,2
        "Francesco;Oggi finalmente inizia la mia vita in città, ero proprio stanco del lavoro in campagna ma ora tutto sarà diverso finalmente il futuro. Oh un altro lavoratore credo che andrò a socializzare", //3
        "Francesco;Ciao",
        "Operaio;Tu devi essere quello nuovo",
        "Francesco;si esatto tu invece sei?",
        "Operaio;Luca,piacere di conoscerti.",
        "Francesco;Piacere Francesco",
        "Luca;Benvenuto all’inferno Francesco",
        "Francesco;Come scusa? questo dovrebbe essere il futuro perchè lo descrivi così?",
        "Luca;Ripetilo tra un mese,ci vediamo al bar",
        "Francesco;Che bar?",
        "Luca;ti ci porterà il mondo",
        "Francesco;Come scusa?",
        "Luca;Niente a dopo",
        "Francesco;Finalmente si inizia il lavora in fabbrica sono sicuro che Luca sia la pecora nera", //(pensato)
        //#DOMANDA 3,4
        "Operaio;Ciao tu devi essere quello nuovo", //17
        "Francesco;Ciao, sono io, Ho iniziato questa mattina, Certo che questo lavoro è molto duro però non è niente rispetto al lavoro in campagna sono fiducioso che quando mi adatterò andrà molto meglio",
        "Operaio;se vieni dalle campagne ti conviene tornarci finchè sei in tempo",
        "Francesco;Tornare in campagna?ma non posso ho venduto tutto per venire qui e poi perché dovrei andarmene questo è il futuro",
        "Operaio;Se questo è il futuro si stava meglio nel passato",
        "Operaio;Comunque gianni mi ha detto di mandarti dal lui terzo piano con una chiave inglese",
        "Francesco;Devono essere 2 le pecore nere e non mi sono nemmeno presentato vabbè ci saranno altre occasioni", // (pensato) 

        "Francesco;Ciao, Sei tu gianni?", //24
        "Gianni;Sì sono io, piacere",
        "Francesco;Ciao Gianni io sono Francesco.Mi sapresti dire come mai tutti odiano lavorare qui?",
        "Gianni;Non odiano il lavoro in sé per quanto duro sia ben sia le condizioni che impone",
        "Francesco;Che condizioni?",
        "Gianni;Ma come non lo sai?",
        "Francesco;No, un mio amico mi ha detto che qui c’è molto lavoro e mi sono fiondato visto che le cose in campagna andavano male",
        "Gianni;Capisco non sei il primo ad accettare questo lavoro per un motivo simile ma vedi proprio perchè c’è così tanta richiesta il proprietario non ci dà tregua",
        "Francesco;in che senso scusa?",
        "Gianni;beh diciamo che ottenere questo lavoro è più difficile che perderlo… e ottenerlo è molto facile",
        "Francesco;Cosa intendi dire? è così facile fare carriera?",
        "Gianni;Per nulla anzi è quasi impossibile.Ciò che intendo è che se ti ammali sei licenziato, se un giorno arrivi in ritardo aspettati che al tuo posto ci sia qualcun altro,e per le donne è anche peggio…",
        "Francesco;Capisco… sono finito proprio all’inferno ma a questo punto è troppo tardi per tornare indietro",
        //#DOMANDA 5,6
        "Francesco;Certo che in questa città le strade sono proprio piene di sporcizia inizio a capire cosa voleva dirmi Luca… \nCredo seguirò il suo consiglio e andrò al bar",
        "Luca;Ciao Francesco sapevo che ti avrei rivisto qui ma non pensavo l’avrei fatto così presto",
        "Francesco;Beh ho pensato che se voglio adeguarmi a questa vita velocizzare il tutto è il modo migliore",
        "Luca;Attento a non velocizzare troppo o perderai il lavoro",
        "Francesco;Che ottimismo...",
        "Luca;Vedi la fabbrica ha aperto 2 anni fa e sono già stati licenziati 650 operai per cui non si tratta di ottimismo ma di dati concreti",
        "Francesco;Ah...capisco però la paga è quasi tre volte superiore rispetto a quella di un contadino credo sia una cosa giusta e poi la vita non è mai stata facile da che ho memoria",
        "Luca;La paga è tre volte superiore ma anche il rischio di perdere tutto lo è",
        "Francesco;Credo che non riuscirò a farti cambiare idea,beviamo qualcosa?",
        "Luca;Ecco ora hai detto una cosa sensata",
        //#DOMANDA 7,8
        "Gianni;Hey Francesco come va è un po che non ci si vede eh?",
        "Francesco;Ciao Gianni in effetti sì qui i turni sono così massacranti che anche lavorando vicini non si riesce a fare quattro chiacchiere",
        "Gianni;Hai pienamente ragione purtroppo che mansione svolgerai oggi?",
        "Francesco;Devo sistemare alcuni tubi a quanto pare c’è stato un guasto",
        "Gianni;Capisco beh cerca di divertirti ci vediamo dopo al bar",
        "Francesco;Sicuramente",
        //*MINIGIOCO*
        "Francesco;Le strade sono piene degli escrementi dei cavalli di quel maledetto del mio capo senza contare che l’acqua dei fiumi ormai a causa dei rifiuti che questa industria ci smaltisce non si può più usare nè per lavarsi né tanto meno per bene credo che andrò a parlargli del resto lavoro qui da oltre 2 anni non credo sarà un problema se gli faccio notare la cosa",
        //#DOMANDE 9,10
        "Francesco;Buongiorno signor Anselmo posso parlarle un minuto?",
        "Anselmo;Scusa oggi non assumo nessuno",
        "Francesco;Ma signore veramente lavoro qui da oltre due anni",
        "Anselmo;ah si? e sentiamo cosa c’è di tanto importante da farmi perdere soldi",
        "Francesco;Ecco volevo chiederle se poteva smettere di riversare i rifiuti di questa industria nel fiume qui vicino e se poteva assicurarsi che i suoi cavalli non sporchino più le strade",
        "Anselmo;HAHAHAHAHAHA Fammi capire tu mi stai facendo perdere soldi perchè anzichè lavorare sei qui a lamentarti e inoltre nella tua posizione osi anche fare delle richieste che richiederebbero un bel po di soldi suppongo quindi che tu sia diventato schifosamente ricco questa notte",
        "Francesco;No signore speravo che potesse usare i suoi soldi per farlo...",
        "Anselmo;Quindi io dovrei pagare per una cosa che posso fare più velocemente in modo gratuito?",
        "Francesco;le acque del fiume non sono più potabili da quando lei ci scarica i suoi rifiuti",
        "Anselmo;Beh questo è un problema del popolo che usi i suoi soldi per risolverlo",
        "Francesco;Ma il popolo non ha molti soldi e se li avesse li utilizzerebbe per pulire le strade dalla sporcizia che lasciano i suoi cavalli...",
        "Anselmo;sai questo mondo ha un sacco di problemi ma a sentire te sembra che io ne sia l’unico responsabile",
        "Francesco;Non voglio accusarla di nulla signore ma vede da quando lavoro qui non ho mai fatto una lamentela o saltato un giorno lavorativo però la situazione per il popolo è ormai insostenibile",
        "Anselmo;Vedrò di essere molto chiaro i miei cavalli hanno più diritti su quelle strade di chiunque altro eccetto me e del fiume non mi interessa non intendo sprecare i miei soldi per una cosa tanto inutile e adesso sparisci sei licenziato.",
        "Francesco;Ma signore… ho svolto il mio lavoro in modo perfetto per oltre 2 anni non può cacciarmi per questo...",
        "Anselmo;Ah no? fuori dai cancelli ogni mattina ci sono centinaia di persona in attesa di avere un lavoro pensi veramente che non troverò uno migliore di te?",
        "Francesco;No signore,scusi se le ho fatto perdere tempo...",
        //#DOMANDA 11,12
        "Protagonista;E questa ragazzo mio è la storia di Francesco,un grande classico dell’era post-riscaldamento globale,se non sbaglio andava molto negli asili non l’hai mai sentita?",
        "Bambino;No,non sono andato all’asilo",
        "Protagonista;Capisco...",
        "Bambino;E poi perchè una cosa così dannosa come la rivoluzione industriale venne portata avanti per così tanto tempo?",
        "Protagonista;Essa in un primo momento portò molti benefici tecnologici e anche importanti scoperte",
        "Bambino;E poi?",
        "Protagonista;Col tempo si fece sempre più presente il problema dello smaltimento dei rifiuti di cui ti ho appena spiegato le origini ma nessuno se ne preoccupo in tempo ed ogni aiuto tardò ad arrivare",
        "Bambino;Non potevate fare nulla per risolvere questo problema?",
        "Protagonista;Ci abbiamo provato con molti modi tra cui  la raccolta differenziata e il riciclaggio ma essi si sono diffusi troppo lentamente e non abbiamo fatto in tempo",
        "Bambino;Non avete capito subito che non era abbastanza?",
        "Protagonista;Se l’avessimo fatto ora non saremmo qui non credi?",
        "Bambino;si ha senso",
        "Protagonista;Inoltre questo non era l’unico problema c’era anche l’inquinamento atmosferico",
        "Bambino;Cosa sarebbe?",
        "Protagonista;Non sei molto informato eh? ma va bene ti racconterò anche questo",

        //per le comparse
        "Operaio;Cosa vuoi?!?", //86
        "Operaio;Levati...",
        "Operaio;Non posso vivere così",
        "Operaio;...",
        "Operaio;Il turno di ieri è stato straziante...",
        "Operaio;Non so come faccio ad essere ancora in piedi"

    };

    public static string[] domande = new string[] {
        "Quando è stato il periodo in cui è avvenuta la Seconda Rivoluzione Industriale?;1800-1850;1850-1900;1750-1800;1700-1750",
        "Come venivano smaltiti i rifiuti chimici prodotto dalle industrie?;Gettati nei fiumi vicini;Trattamento in strutture apposite;Stoccaggio in zone protette;Riutilizzo dei materiali utili per la creazione di altri prodotti",
        "Quale era il tasso nazionale italiano di analfabetismo nei primi del 1900?;2%;94%;56%;37%",
        "Quanta acqua che si trova in natura si può bere tranquillamente?;95%;60%;35%;1%",
        "Da quale paese origina la rivoluzione?;Germania;Inghilterra;Italia;Stati Uniti",
        "Quale tipo di motore fu inventato in questi anni?;Il motore a scoppio;Il motore a dinamite;il motore a molla;Il motore a getto"
    };
}
