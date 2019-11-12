import { Injectable } from '@angular/core';
import { DbndService } from '../dbnd/dbnd.service';
import { AuthService } from '../auth/auth.service';
import { BehaviorSubject, Observable } from 'rxjs';
import { Overview } from 'src/app/_models/overview';

@Injectable({
  providedIn: 'root'
})
export class OverviewService {

  constructor(private dbnd: DbndService, private auth: AuthService, public gameId: string) {
    this.updateOverviews();
  }

  private _overviews: BehaviorSubject<Overview[]> = new BehaviorSubject([]);
  public readonly overviews$: Observable<Overview[]> = this._overviews.asObservable();

  public async updateOverviews() {
    this.dbnd.getGameOverviews$(await this.auth.getClientId(), this.gameId)
    .subscribe( res => {this._overviews.next(res as Overview[]);
    });
  }
}
