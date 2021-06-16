package UI;

import javafx.application.Application;
import javafx.collections.FXCollections;
import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import static javafx.geometry.HPos.RIGHT;

import classes.Dataset;
import classes.GPU;
import javafx.geometry.Insets;
import javafx.geometry.Pos;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.PasswordField;
import javafx.scene.control.TextField;
import javafx.scene.layout.GridPane;
import javafx.scene.layout.HBox;
import javafx.scene.paint.Color;
import javafx.scene.text.Font;
import javafx.scene.text.FontWeight;
import javafx.scene.text.Text;
import javafx.stage.Stage;


import javafx.collections.ObservableList;

import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;
import javafx.scene.control.cell.PropertyValueFactory;


public class Menu extends Application {

    public Parent createContent() {
        
        Dataset ds = new Dataset();
        final ObservableList<GPU> data = FXCollections.observableArrayList(ds.getList());

        TableColumn rank = new TableColumn();
        rank.setText("Rank");
        rank.setCellValueFactory(new PropertyValueFactory("ranking"));

        TableColumn name = new TableColumn();
        name.setText("Name");
        name.setCellValueFactory(new PropertyValueFactory("name"));

        TableColumn marPercent = new TableColumn();
        marPercent.setText("March %");
        marPercent.setCellValueFactory(new PropertyValueFactory("marPercent"));

        TableColumn aprPercent = new TableColumn();
        aprPercent.setText("April %");
        aprPercent.setCellValueFactory(new PropertyValueFactory("aprPercent"));

        TableColumn mayPercent = new TableColumn();
        mayPercent.setText("May %");
        mayPercent.setCellValueFactory(new PropertyValueFactory("mayPercent"));

        TableColumn junPercent = new TableColumn();
        junPercent.setText("June %");
        junPercent.setCellValueFactory(new PropertyValueFactory("junPercent"));

        TableColumn julPercent = new TableColumn();
        julPercent.setText("July%");
        julPercent.setCellValueFactory(new PropertyValueFactory("julPercent"));

        TableColumn change = new TableColumn();
        change.setText("Change %");
        change.setCellValueFactory(new PropertyValueFactory("change"));

        final TableView tableView = new TableView();
        tableView.setItems(data);
        tableView.getColumns().addAll(rank, name, marPercent, aprPercent, mayPercent, junPercent, julPercent, change);
        tableView.setStyle("-fx-background-color: #1b2838");
        return tableView;
    }

    @Override public void start(Stage primaryStage) throws Exception {
        primaryStage.setScene(new Scene(createContent(), 1000, 500));
        primaryStage.show();
    }
    /*
    @Override
    public void start(Stage primaryStage) {
        
        primaryStage.setTitle("Steam Hardware Survey");
        
        GridPane grid = new GridPane();
        grid.setAlignment(Pos.CENTER);
        grid.setHgap(50);
        grid.setVgap(100);
        grid.setPadding(new Insets(25, 25, 25, 25));
        grid.setStyle("-fx-background-color: #1b2838");

        

        Scene scene = new Scene(grid, 1000, 500);
        primaryStage.setScene(scene);
        primaryStage.show();
        
    }
    */

    public static void main(String[] args) {
        launch(args);
    }

}
