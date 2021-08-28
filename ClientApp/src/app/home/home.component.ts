import { Component, OnInit } from '@angular/core';
import { HomeService } from './home.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  public infos: any[]  = [];
  public haydatos:boolean = true;

  constructor(private homeService: HomeService) {}

  ngOnInit(): void {
    this.traerTodos();
  }

  traerTodos() {
    this.homeService.getInfos().subscribe((infoData: any[])=>{
	  if(infoData.length){
		this.infos = [];
		this.haydatos = true;
		  infoData.forEach(element => {
			this.infos.push({
			  id: element.id,
			  name : element.name,
			  age : element.age
			});
		  })
	 }else{
		 this.haydatos = false;
	 }
    }, error => console.error(error))
  }

  alta(data){
    this.homeService.createInfo(data.value).subscribe(datos=>{
		//console.log(datos.id)[revisar] infoController line29 
		this.traerTodos();
		data.reset();
	});
  }
  
  baja(codigo) {
    this.homeService.baja(codigo).subscribe(datos=>{
      this.traerTodos();
    });
  }

  modificar(codigo, data){
    this.homeService.modificar(codigo, data).subscribe(datos=>{
      this.traerTodos();
    });
  }

}
