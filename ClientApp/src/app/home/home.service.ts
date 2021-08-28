import { Injectable , Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class HomeService {

    private baseUrl: string;

    private httpOptions = {
        headers: new HttpHeaders({
          'Accept': 'application/json',
          'Content-Type': 'application/json',
        })
    };

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) { 
        this.baseUrl = baseUrl;
    }

   
    public getInfos() {
        return this.http.get(this.baseUrl + 'api/info');
    }

    public createInfo(data) {
		return this.http.post(this.baseUrl + 'api/info', JSON.stringify(data), this.httpOptions );
    }

    public baja(codigo:number) {
      console.log("Eliminado: " + codigo)
      return this.http.delete(this.baseUrl + `api/info/${codigo}`,  this.httpOptions );
    }

    public modificar(codigo:number, data){
      console.log(" Modificado: " + codigo)
      return this.http.put(this.baseUrl + `api/info/${codigo}`, JSON.stringify(data), this.httpOptions);
    }

}