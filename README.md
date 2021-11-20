Notre équipe est composée de Jérémy Huard et de Samuel Daigle

Pour régler l'erreur dans la naviguation vers la page commande:
l'erreur était que la PageCommande avait été créée comme une Window au lieu d'une Page, dans PageCommandes.xaml.cs la classe héritait de Window au lieu de Page, ce que nous avons rectifié, et dans PageCommandes.xaml la première balise était une balise Window au lieu de Page que nous avons aussi changé. Nous avons aussi changé la ligne qui déclenchait la navigation vers la page Commande au clic sur le bouton qui était:
  this.NavigationService.Navigate(new Uri("Pages/PageCommandes.xaml", UriKind.Relative));
pour:
  NavigationService.Navigate(frmCommandes);
