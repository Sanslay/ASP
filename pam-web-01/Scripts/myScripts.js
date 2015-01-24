// variables globales
var loading;
var content;
var lnkFaireSimulation;
var lnkEffacerSimulation
var lnkEnregistrerSimulation;
var lnkTerminerSession;
var lnkVoirSimulations;
var lnkRetourFormulaire;
var options;
// Tous les scriptes sont ajouter au page web
// au chargement du document
$(document).ready(function () {
  // on récupère les références des différents composants de la page
  loading = $("#loading");
  content = $("#content");
  // les liens du menu
  lnkFaireSimulation = $("#lnkFaireSimulation");
  lnkEffacerSimulation = $("#lnkEffacerSimulation");
  lnkEnregistrerSimulation = $("#lnkEnregistrerSimulation");
  lnkVoirSimulations = $("#lnkVoirSimulations");
  lnkTerminerSession = $("#lnkTerminerSession");
  lnkRetourFormulaire = $("#lnkRetourFormulaire");

  // on les met dans un tableau
  options = [lnkFaireSimulation, lnkEffacerSimulation, lnkEnregistrerSimulation,
  lnkVoirSimulations, lnkTerminerSession, lnkRetourFormulaire];
  // on cache certains éléments de la page
  loading.hide();
  // on fixe le menu
  setMenu([lnkFaireSimulation, lnkVoirSimulations, lnkTerminerSession]);
});


function setMenu(show) {
  // on affiche les liens du tableau [show]
  for (i = 0; i < options.length; i++) {
    options[i].hide();
  }

  for (i = 0; i < show.length; i++) {
    show[i].show();
  }

}

function faireSimulation() {


  // d'abord les références sur le DOM
  var formulaire = $("#formulaire");
  var simulation = $("#simulation");
  simulation.show();
  
  if (!formulaire.validate().form()) {
    // formulaire invalide - terminé
    return;
  }
  //On affiche ce que l'on veux
  setMenu([lnkEffacerSimulation, lnkVoirSimulations, lnkTerminerSession, lnkEnregistrerSimulation]);
  // on fait un appel Ajax à la main
    //Appelle de la fonction faire Simulation qui ce trouve dans le controleur il nous retournera des PartialViewResult 
  $.ajax({
    url: '/Pam/faireSimulation',
    type: 'POST',
    data: formulaire.serialize(),
    dataType: 'html',


    success: function (data) {
      simulation.html(data);
    },
  })
}

function effacerSimulation() {
  setMenu([lnkFaireSimulation, lnkEffacerSimulation, lnkVoirSimulations, lnkTerminerSession]);
  // on efface la simulation

  var simulation = $("#simulation");
  simulation.hide()
  /**************************/
  var A = $("#HeuresTravaill_es");
  var B = $("#JoursTravaill_s");
  // on affecte des valeurs valides aux saisies
  A.val("");
  B.val("");



}
//Appelle de la fonction EnregisterSimulation qui ce trouve dans le controleur il nous retournera des PartialViewResult 

function enregistrerSimulation() {

  setMenu([lnkRetourFormulaire, lnkTerminerSession]);
  // on fait un appel Ajax à la main
  $.ajax({
    url: '/Pam/EnregisterSimulation',
    type: 'POST',
    data: content.serialize(),
    dataType: 'html',

    success: function (data) {
      content.html(data);
    },

  })

}
//Appelle de la fonction RetirerSimulation qui ce trouve dans le controleur il nous retournera des PartialViewResult 

function retirerSimulation(N) {

    // on fait un appel Ajax à la main
  $.ajax({
    url: '/Pam/RetirerSimulation',
    type: 'POST',
    data: "num="+N,
    success: function (data) {
      content.html(data);
    },

  })

}
//Appelle de la fonction voirSimulations qui ce trouve dans le controleur il nous retournera des PartialViewResult 
function voirSimulations() {
  setMenu([lnkRetourFormulaire, lnkTerminerSession]);
  // on fait un appel Ajax à la main
  $.ajax({
    url: '/Pam/voirSimulations',
    type: 'POST',
    data: content.serialize(),
    dataType: 'html',

    success: function (data) {
      content.html(data);
    },
  })


}
//Appelle de la fonction Formulaire qui ce trouve dans le controleur il nous retournera des PartialViewResult 
function retourFormulaire() {

  setMenu([lnkFaireSimulation, lnkVoirSimulations, lnkTerminerSession]);
  // on fait un appel Ajax à la main

  $.ajax({
    url: '/Pam/Formulaire',
    type: 'POST',
    data: content.serialize(),
    dataType: 'html',

    success: function (data) {
      content.html(data);
    },

  })
}
//Appelle de la fonction TerminerSession qui ce trouve dans le controleur il nous retournera des PartialViewResult 

function terminerSession() {
  setMenu([lnkFaireSimulation, lnkVoirSimulations, lnkTerminerSession]);
  // on fait un appel Ajax à la main

  $.ajax({
    url: '/Pam/TerminerSession',
    type: 'POST',
    data: content.serialize(),
    dataType: 'html',

    success: function (data) {
      content.html(data);
    },

  })
}
