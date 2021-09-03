import { Component } from '@angular/core';
import { TreeItem } from './models/tree-item';
import { StructureService } from './services/structure.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  public treeItem: TreeItem;
  title = 'labaton-front';

  constructor(private structureService: StructureService) { }

  ngOnInit(): void {
    this.structureService.getStructure("").subscribe(response => {
      this.treeItem = response;
    });
  }
}
