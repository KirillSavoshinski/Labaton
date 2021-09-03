import { Component, OnInit } from '@angular/core';
import { StructureService } from '../services/structure.service';

@Component({
  selector: 'app-tree',
  templateUrl: './tree.component.html',
  styleUrls: ['./tree.component.scss']
})
export class TreeComponent implements OnInit {

  constructor(private structureService: StructureService) { }

  ngOnInit(): void {
    this.structureService.getStructure("D://").subscribe(response => {
      console.log(response);
    })
  }

}
