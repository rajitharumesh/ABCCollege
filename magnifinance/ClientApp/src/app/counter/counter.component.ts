import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent {
  public currentCount = 0;
    forecasts: any[] | undefined;
  httpClient: HttpClient;
  baseUrl = "";
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.httpClient = http;
    this.baseUrl = baseUrl;
    http.get<any[]>(baseUrl + 'course').subscribe(result => {
      console.log("ddfdfdfdfd");
    }, error => console.error(error));
  }

  public incrementCounter() {
    this.currentCount++;
    this.httpClient.get<any[]>(this.baseUrl + 'course').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }
}
