import { Component } from '@angular/core';
import { AdminService } from '../../services/post.service';
import { from } from 'rxjs';
import { map } from 'rxjs/operators';
//import { AgGridModule } from 'ag-grid-angular'

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
})
export class AdminComponent {
  private rowDataName=[];
 

  objCategory = "";
  category: Category;
  successMsg = "";

  hideShowAlertMsg = false;
  colorCode: string;
  //rowDataName = [];

  constructor(private _adminService: AdminService) {

   

  }

  ngOnInit() {
    debugger;
    this.getGridDataCategories();
  }



  getGridDataCategories() {
    this._adminService.GetCategories()
      .subscribe((data: any) => {
        this.rowDataName = data;
      },
        err => console.log(err))
  }

  AddCategory() {

    this.category = {
      Id: 0,
      Name: this.objCategory,
      Slag: this.objCategory
    };

    this._adminService.AddCategories(this.category)
      .subscribe(
        (data: any) => {
          if (data != null && data != "") {
            
            this.getGridDataCategories();
            this.DisplayMessage("Category Added Successfully", true);

          }
          else {
            this.DisplayMessage("Category is not added due to internal error", false);
          }
        });
  }

  DisplayMessage(msg, isSuccess) {
    this.hideShowAlertMsg = true;
    this.successMsg = msg;
    this.colorCode = isSuccess == true ? "success" : "danger";
  }
}



export class Category {
  Id: any;
  Name: any;
  Slag: any;
}
