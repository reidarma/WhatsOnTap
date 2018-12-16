import { Component, OnInit } from '@angular/core';

import { Global } from '../shared/global';
import { BeerService } from '../services/beer.service';
import { StyleService } from '../services/style.service';
import { TapService } from '../services/tap.service';
import { SettingService } from '../services/setting.service';
import { ITap } from '../models/tap';
import { ISetting } from '../models/setting';
import { IStyle } from '../models/style';
import { IBeer } from '../models/beer';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {
  loadingState: boolean;
  taps: ITap[];
  brewerySettings: object;
  background: string;

  constructor(private _beerService: BeerService, private _styleService: StyleService, private _tapService: TapService, private _settingService: SettingService) { }

  ngOnInit() {
    this.brewerySettings = {};
    this.loadingState = true;
    this.loadData();
  }

  loadData(){
    this._settingService.getAllSettings(Global.BASE_SETTING_ENDPOINT)
      .subscribe(settings =>{
        this._tapService.getAllTaps(Global.BASE_TAP_ENDPOINT)
          .subscribe(taps =>{
            this._styleService.getAllStyles(Global.BASE_STYLE_ENDPOINT)
              .subscribe(styles => {
                this._beerService.getAllBeers(Global.BASE_BEER_ENDPOINT)
                  .subscribe(beers => {
                    this.setupMenu(settings, taps, styles, beers);
                  });
              });
          });
      });
  }

  setupMenu(settings: ISetting[], taps: ITap[], styles: IStyle[], beers: IBeer[]){
    this.loadingState = false;

    settings.forEach(setting => {
      this.brewerySettings[setting.key] = setting;
    });

    var backgroundByteArr = this.brewerySettings["MenuBackground"]["byteArrValue"];
    if (backgroundByteArr == null){
      this.background = "black";
    }
    else{
      this.background = "url(data:image/jpg;base64,"+backgroundByteArr+")";
    }

    beers.forEach((b)=>{
      b.style = styles.find((s)=>{return s.id == b.styleId;});
      b.labelSrc = `data:image/png;base64,${b.label}`;
    });

    taps.forEach((t)=>{
      t.beer = beers.find((b) => {return b.id == t.beerId;});
    })

    this.taps = taps
      .sort((a, b) => {
        return a.order < b.order ? -1 : 1;
      });
  }
}
